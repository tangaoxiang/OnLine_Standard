var cspName = "Longmai mToken GM3000 CSP V1.1"; //龙脉驱动

var singID;
var comID;

function getCert() {
    var CryptAPICtrl = document.getElementById("CryptAPICtrl");

    //var ini = CryptAPICtrl.KGCryptInitialize(cspName, "", 0, 0xf0000000);
    var ini = CryptAPICtrl.KGCryptInitialize(cspName, "", 1, 4026531840);//0xf0000000
    //alert(ini);
    var ctns = CryptAPICtrl.KGCryptGetContainers(0);
    //alert(ctns);
    var ctnArray = ctns.split("\n");
    //alert(ctnArray);
    CryptAPICtrl.KGCryptFinalize(0);

    // 连接到相应的证书，默认获取第一个
    var sss = CryptAPICtrl.KGCryptInitialize(cspName, ctnArray[0], 1, 0);
    //alert(sss);
    var ret = CryptAPICtrl.KGCryptGetUserKey(2);
    if (ret) {
        ret = CryptAPICtrl.KGCryptGetUserKey(1);
        if (!ret) keyspec = 1;
    }
    //// 获取公钥
    var cer = CryptAPICtrl.KGCryptExportKey(0, 1, 0);
    CryptAPICtrl.KGCryptFinalize(0);
    //alert("333");
    return cer;

}


function calculateHash(type, fileIDS, keyPwd, xPoint, yPoint, chkSignatureDtflag, chkSignatureAllPagePdfflag, signaturePagen) {
    //alert(chkSignatureDtflag + "-----------" + chkSignatureAllPagePdfflag + "-----------" + signaturePagen + "-----------");
    var cert;
    try {
        cert = getCert();
        if (cert == undefined) {
            alert("请插入有签名证书的密钥盘！");
            return;
        }
    } catch (e) {
        alert("请重新安装客户端：" + e.message);
        return;
    }

    var seal = getSeals(type);
    if (seal === null || typeof (seal) == "undefined" || typeof (seal) == "string") {
        alert(seal);
        return;
    }

    $.ajax({
        url: "/KGHandlerEx.ashx",
        type: "POST",
        dataType: "json",
        data: {
            "rn": Math.random(),
            "option": "calculateHash",
            "cert": cert,
            "fileIDS": fileIDS,
            "xPoint": xPoint,
            "yPoint": yPoint,
            "signatureDtflag": chkSignatureDtflag,
            "signatureAllPagePdfflag": chkSignatureAllPagePdfflag,
            "signaturePagen": escape(signaturePagen),
            "imgData": seal.ImgValue,
            "imgWidth": seal.Width,
            "imgHeight": seal.Height,
            "imgExt": seal.SignExt
        },
        success: function (data) {
            $.each(data, function (index, item) {
                var hash = item.hash;
                var contentsPostion = item.contentsPostion;

                var CryptAPICtrl = document.getElementById("CryptAPICtrl");
                CryptAPICtrl.KGCryptInitialize(cspName, "", 1, 0xf0000000);
                var ctns = CryptAPICtrl.KGCryptGetContainers(0);
                var ctnArray = ctns.split("\n");
                CryptAPICtrl.KGCryptFinalize(0);

                // 连接到相应的证书，默认获取第一个  
                for (var i = 0 ; i < ctnArray.length; i++) {
                    var ctnname = ctnArray[i];
                    if (ctnname) {
                        if (keyPwd != "") {
                            CryptAPICtrl.KGCryptInitialize(cspName, ctnArray[i], 1, 0x40);
                            var pwd = stringToHex(keyPwd) + "00";
                            CryptAPICtrl.KGCryptSetPin(pwd, pwd.length, 32);
                        } else {
                            CryptAPICtrl.KGCryptInitialize(cspName, ctnArray[i], 1, 0);
                        }
                        var isEncipherCert;
                        var ret = CryptAPICtrl.KGCryptGetUserKey(isEncipherCert ? 1 : 2);
                        if (ret == 0) {
                            break;
                        } else {
                            CryptAPICtrl.KGCryptFinalize(0);
                        }
                    }
                }

                /*------------------------开始：可以循环调用-------------------------------*/
                // 需要签名数据的16进制
                //MD5: 0x00008003; SHA1: 0x00008004
                CryptAPICtrl.KGCryptCreateHash(0x00008004);
                CryptAPICtrl.KGCryptSetHashValue(hash, hash.length);

                // 签名后的数据			
                item.contents = CryptAPICtrl.KGCryptSignHash(2, 0);
                CryptAPICtrl.KGCryptDestroyHash();
                /*------------------------结束：可以循环调用-------------------------------*/
                CryptAPICtrl.KGCryptFinalize(0);
            });
            rewriteSigned(cert, data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            if (XMLHttpRequest.responseText.indexOf("系统签章过期") > -1) {
                alert("系统授权文件过期,请联系管理员更新文件！");
            }
            else if (XMLHttpRequest.responseText.indexOf("系统签章异常") > -1) {
                alert("系统签章异常:" + XMLHttpRequest.responseText);
            }
        }
    });
}


function rewriteSigned(cert, jArray) {
    $.ajax({
        url: "/KGHandlerEx.ashx",
        type: "POST",
        data: {
            "option": "rewriteSigned",
            "cert": cert,
            "jArray": JSON.stringify(jArray)
        },
        success: function (data) {
            alert(data);
            location.href = location.href; //刷新当前页面
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //alert("222")
            alert("后台出现异常:" + XMLHttpRequest.responseText);
        }
    });
}


function stringToHex(str) {
    var val = "";
    for (var i = 0; i < str.length; i++) {
        if (val == "") {
            val = str.charCodeAt(i).toString(16);
        }
        else {
            val += str.charCodeAt(i).toString(16);
        }
    }
    return val;
}
/*
16、HeadInformations (接口)
功能描述：调用WebLoadSign 后，获取单个签章扩展数据接口。
参数：Index: INT；获取签章索引号（从0 开始）
返回值：IHeadInformations 接口
IHeadInformations 接口属性如下：
Position：BSTR； 签章在KEY 内存储的位置信息
SerialNumber：BSTR；签章的序列号
UserName： BSTR；签章的持有人用户名称
SignName： BSTR；签章的签章名称
SignPass：BSTR；签章密码
SignExt：BSTR；签章图片扩展名
Width：BSTR；签章图片宽度
Height：BSTR；签章图片高度
ImgValue：BSTR；签章图片信息
KeySN： BSTR；签章KEY 序列号
UnitName： BSTR；签章KEY 单位名称
ImgTag : 公私章标识，0公章 1私章
调 用 ：
SignatureManage . .HeadInformations(0).ImgValue；
*/
function getSeals(imgTag) {
    var SMObj = document.getElementById("SMObj");
    try {
        var mResult = SMObj.LoadSignature(true);
        if (mResult != 0) {
            if (mResult == 11) {
                return '没有检测到电子钥匙盘！';
            }
            //alert('没有检测到电子钥匙盘！');
            return '没有检测到电子钥匙盘！';
        };
    } catch (e) {
        //alert("请安装签章客户端！");
        return "请安装签章客户端！";
    }

    for (var i = 0; i < SMObj.SignCount; i++) {
        var signObj = SMObj.HeadInformations(i);
        if (imgTag) {
            if (signObj.ImgTag == imgTag) {
                return signObj;
            }
        } else {
            return signObj;
        }
    }
    //alert('电子密钥盘没有印章！');
    return '电子密钥盘没有印章！';
}

function WebOpen() {
    iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.WebUrl = url;
    var tempFile = iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.CreateTempFileName();
    iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("DBSTEP", "DBSTEP");
    iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("OPTION", "LOADFILE");
    //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("FILETYPE","PDF");
    //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("USERNAME","演示人");
    //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("RECORDID",mRecordID);
    //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("FILENAME","1385716767003.pdf");
    if (iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.PostDBPacket(false)) {
        iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.MsgFileSave(tempFile);

        iWebPDF2015.Documents.Open(tempFile);
        iWebPDF2015.Documents.ActiveDocument.Views.ActiveView.Zoom = 100;
        alert("打开成功");
    }
    else {
        alert("打开失败");
    }
}


//打开文档
function WebOpen(id) {
    if (typeof (id) != "undefined") {
        iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.WebUrl = url;
        var tempFile = iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.CreateTempFileName();
        iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("DBSTEP", "DBSTEP");
        iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("OPTION", "LOADFILE");
        //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("FILETYPE","PDF");
        //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("USERNAME","演示人");
        iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("RECORDID", id);
        //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("FILENAME", fileName);
        if (iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.PostDBPacket(false)) {
            iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.MsgFileSave(tempFile);

            iWebPDF2015.Documents.Open(tempFile);
            //iWebPDF2015.Documents.ActiveDocument.Views.ActiveView.Zoom = 100;
            //alert("打开成功");
        }
        else {
            alert("打开失败");
        }
    }
    else {
        alert("文件不存在");
    }

}

/**文档保存**/
function saveFile(id) {
    try {
        //在线保存文档
        if (0 == iWebPDF2015.Documents.Count) {
            alert("没有要保存的文档");
            return;
        }


        var obj = iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object;
        obj.WebUrl = url;
        iWebPDF2015.Documents.ActiveDocument.Save();//保存当前文档
        var pdfPath = iWebPDF2015.Documents.ActiveDocument.FileInformation.FileLocation + iWebPDF2015.Documents.ActiveDocument.FileInformation.FileName;
        obj.MsgFileLoad(pdfPath);//FileLocation FileSize FileName ModDate CreationDate
        obj.SetMsgByName("DBSTEP", "DBSTEP");
        obj.SetMsgByName("OPTION", "SAVEFILE");
        obj.SetMsgByName("RECORDID", id);



        //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.WebUrl = url;
        //var tempFile = iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.CreateTempFileName();
        //iWebPDF2015.Documents.ActiveDocument.Save(tempFile);
        //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.MsgFileLoad(tempFile);
        //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("DBSTEP", "DBSTEP");
        //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("OPTION", "SAVEFILE");
        ////iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("FILETYPE","PDF");
        ////iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("USERNAME","演示人");
        //iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.SetMsgByName("RECORDID", id);

        //if (iWebPDF2015.COMAddins("KingGrid.MsgServer2000").Object.PostDBPacket(false)) {
        if (obj.PostDBPacket(false)) {
            $('#Subject').val($('#txtSubject').val());
            $('#Author').val($('#txtAuthor').val());
            $('#iWebPDF').submit();
            //  alert("保存成功！文档编号是：" + id);
            return "success";
        }
        else {
            alert("保存失败！");
        }
    } catch (e) {
        alert("打开失败" + e.description);
    }
}
