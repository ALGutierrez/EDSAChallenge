// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function LoadModalSimpleHtml(message, title, buttons, width) {
    $('#modal-title').html(title);
    $('#modal-body-content').html(message);
    var modalButtons = '';
    $(buttons).each(function (index, button) {
        modalButtons += '<a href="javascript:' + button.Action + '" class="' + button.CssClass + '">' + button.Text + '</a>';
    });
    $('#modal-buttons').html(modalButtons);
    if (width != undefined || width != "")
        $(".modal-dialog").css("width", width);
    openMod('modal-container');
}

function CreateActionModalButton(text, action) {
    return { Action: action, CssClass: 'btn btn-primary', Text: text };
}
function CreateCloseModalButton(text) {
    return { Action: "CloseModal();", CssClass: 'btn btn-default', Text: text };
}