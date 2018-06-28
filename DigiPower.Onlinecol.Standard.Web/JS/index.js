var HomepageFavorite = {
    //设为首页
    Homepage: function () {
        if (document.all) {
            document.body.style.behavior = 'url(#default#homepage)';
            document.body.setHomePage(window.location.href);

        }
        else if (window.sidebar) {
            if (window.netscape) {
                try {
                    netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                }
                catch (e) {
                    alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true");
                    history.go(-1);
                }
            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', window.location.href);
        }
    }
        ,
    //加入收藏
    Favorite: function Favorite(sURL, sTitle) {
        try {
            window.external.addFavorite(sURL, sTitle);
        }
        catch (e) {
            try {
                window.sidebar.addPanel(sTitle, sURL, "");
            }
            catch (e) {
                alert("加入收藏失败,请手动添加.");
            }
        }
    }
}

function emailCall(email, sub) {
    parent.location = 'mailto:' + email + '?subject=' + sub;
}

function emailCall1(email) {
    parent.location = 'mailto:' + email + '?subject=用户反馈';
}

function SubMit() {//登录
    var username = document.getElementById('txtUserName').value;
    var pwd = document.getElementById('txtPwd').value;

    if (username == '') {
        alert('用户名不能为空！');
        document.getElementById('txtUserName').focus();
        return;
    }
    if (pwd == '') {
        alert('密码不能为空！');
        document.getElementById('txtPwd').focus();
        return;
    }
    var len = UserLoginGather.Login(username, pwd).value;
    if (len == 'success') {
        window.location.replace('Main.aspx'); //Main.aspx
    }
    else if (len == "failure") {
        alert("用户账号或密码错误或账号被禁用，如果您已经成功注册，请等待确认后再登录！");
    }
    else {
        alert(len);
    }
}

function onKeyDown(el) {//回车提交
    var e = el || window.event;
    var keyCode = e.which || e.keyCode;
    if (keyCode == 13) {
        SubMit();
    }
}

function onStartLoad() {
    if (document.getElementById('txtUserName').value != "") {
        document.getElementById('txtPwd').focus();
    }
}

function onOpen(width, height, url) {
    //var url = "ArchiverRegister.aspx"; // 
    var top = (window.screen.height - height) / 2;
    var left = (window.screen.width - width) / 2;
    window.open(url, '', 'top=' + top + ',left=' + left + ' ,width=' + width + ',height=' + height +
        ',location=no,menubar=no,resizable=no,toolbar=no,titlebar=no,status=no,scrollbars=yes');
    return false;
}