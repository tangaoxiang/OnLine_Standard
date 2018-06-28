<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlSwfUpload.ascx.cs" Inherits="DigiPower.Onlinecol.Standard.Web.CommonCtrl.ctrlSwfUpload" %>
<link href="../css/SwfUpload.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src='<%=ResolveUrl("~/JS/swfupload/swfupload.js")%>'></script>
<script type="text/javascript" src='<%=ResolveUrl("~/JS/swfupload/handlers.js")%>'></script>
<script type="text/javascript" language="javascript">
    
		window.onload = function () {
		    
		    var swfu;
		    swfu = new SWFUpload({
				// Backend Settings
				upload_url: "<%=ResolveUrl(_savePageUrl)%>",
                post_params : {
                    "ASPSESSID" : "<%=Session.SessionID %>"
                },

				// File Upload Settings
				file_size_limit : "<%=_maxSize %> MB",
				file_types : "<%=_fileType %>",
				file_types_description : "<%=_fileTypesDescription %>",
				file_upload_limit : "<%=_maxQueue %>",    // Zero means unlimited

				// Event Handler Settings - these functions as defined in Handlers.js
				//  The handlers are not part of SWFUpload but are part of my website and control how
				//  my website reacts to the SWFUpload events.
				
				file_queue_error_handler : fileQueueError,
				file_dialog_complete_handler : fileDialogComplete,
				upload_progress_handler : uploadProgress,
				upload_error_handler : uploadError,
				upload_success_handler : uploadSuccess,
				upload_complete_handler : uploadComplete,

				// Button settings
				button_image_url : '<%=ResolveUrl("~/images/swfupload/XPButtonNoText_160x22.png") %>',
				button_placeholder_id : "spanButtonPlaceholder",
				button_width: 160,
				button_height: 22,
				button_text : '<span class="button">选择上传文件 <span class="buttonSmall">(最大<%=_maxSize %>兆)</span></span>',
				button_text_style : '.button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }',
				button_text_top_padding: 1,
				button_text_left_padding: 5,

				// Flash Settings
				flash_url : '<%=ResolveUrl("~/JS/swfupload/swfupload.swf")%>',	// Relative to this file

				custom_settings : {
					upload_target : "divFileProgressContainer"
				},

				// Debug Settings
				debug:  false
			});
		}
</script>

<br /><br /><br />
<div id="content">
    <div id="swfu_container" style="margin: 0px 10px;">
	    <div>
			<span id="spanButtonPlaceholder"></span>
	    </div>
	    <div id="divFileProgressContainer" style="height: 75px;"></div>
	    <div id="thumbnails"></div>
	    <div style="color:Red;">
	        导入说明：可以一次选取多个文件导入。
	    </div>
    </div>
</div>
