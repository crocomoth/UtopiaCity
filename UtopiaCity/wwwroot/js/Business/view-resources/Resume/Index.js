$(document).ready(function () {
    $('#GetResumeButtonId').click(function (e) {
        var filter = $('#ResumeFilterId').val();
        filter = encodeURIComponent(filter);
        var url = '/Resume/Index/?filter=' + filter;
        $('#TableDivId').load(url);
    });
});