var ALERT_TITLE = "Send Status";
var ALERT_BUTTON_TEXT = "OK";

if (document.getElementById) {
	window.alert = function (txt) {
		createCustomAlert(txt);
	}
}

function createCustomAlert(txt) {
	d = document;

	if (d.getElementById("modal")) return;

	mObj = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
	mObj.id = "modal";
	mObj.style.height = d.documentElement.scrollHeight + "px";

	alertObj = mObj.appendChild(d.createElement("div"));
	alertObj.id = "modal-dialog";

	//if (d.all && !window.opera) alertObj.style.top = document.documentElement.scrollTop + "px";
	//alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth) / 2 + "px";
	alertObj.style.visiblity = "visible";

	h5 = alertObj.appendChild(d.createElement("h5"));
	h5.id  = "modal-header"
	h5.appendChild(d.createTextNode(ALERT_TITLE));

	msg = alertObj.appendChild(d.createElement("p"));
	msg.id = "modal-body";
	msg.appendChild(d.createTextNode(txt));
	msg.innerHTML = txt;

	btn = alertObj.appendChild(d.createElement("button"));
	btn.id = "btn-secondary";
	btn.appendChild(d.createTextNode(ALERT_BUTTON_TEXT));
	btn.type = "button";
	btn.focus();
	btn.onclick = function () { removeCustomAlert(); return false; }

	alertObj.style.display = "block";

}

function removeCustomAlert() {
	document.getElementsByTagName("body")[0].removeChild(document.getElementById("modal"));
}
function ful() {
	alert('Alert this pages');
}