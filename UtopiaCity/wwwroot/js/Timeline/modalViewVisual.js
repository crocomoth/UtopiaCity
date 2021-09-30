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

	modalWrapper = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
	modalWrapper.id = "modal";
	modalWrapper.style.height = d.documentElement.scrollHeight + "px";

	alertWrapper= modalWrapper.appendChild(d.createElement("div"));
	alertWrapper.id = "modal-dialog";
	alertWrapper.style.visiblity = "visible";

	//if (d.all && !window.opera) alertWrapper.style.top = document.documentElement.scrollTop + "px";
	//alertWrapper.style.left = (d.documentElement.scrollWidth - alertWrapper.offsetWidth) / 2 + "px";

	h5 = alertWrapper.appendChild(d.createElement("h5"));
	h5.id  = "modal-header"
	h5.appendChild(d.createTextNode(ALERT_TITLE));

	msg = alertWrapper.appendChild(d.createElement("p"));
	msg.id = "modal-body";
	msg.appendChild(d.createTextNode(txt));
	msg.innerHTML = txt;

	btn = alertWrapper.appendChild(d.createElement("button"));
	btn.id = "btn-secondary";
	btn.appendChild(d.createTextNode(ALERT_BUTTON_TEXT));
	btn.type = "button";
	btn.focus();
	btn.onclick = function () { removeCustomAlert(); return false; }

	alertWrapper.style.display = "block";

}

function removeCustomAlert() {
	document.getElementsByTagName("body")[0].removeChild(document.getElementById("modal"));
}
function ful() {
	alert('Alert this pages');
}