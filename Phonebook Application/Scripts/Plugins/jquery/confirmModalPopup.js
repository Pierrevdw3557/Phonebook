function ShowModal(title, body) {
    $(".global_modal").find(".modal-body").html(body);
    $(".global_modal").find(".modal-title").html(title);
    $(".global_modal").modal('show');
}

function ShowSmallModal(title, body) {
    $(".global_modal_sml").find(".modal-body").html(body);
    $(".global_modal_sml").find(".modal-title").html(title);
    $(".global_modal_sml").modal({ backdrop: 'static' });
    $(".global_modal_sml").modal('show');
}

function HideModal() {
    $(".global_modal").modal('hide');
    $(".modal-large").modal('hide');
}

function ShowLoader() {
    $("<div class='oeloader' />").css({
        'position': 'fixed',
        'left': 0,
        'right': 0,
        'bottom': 0,
        'top': 0,
        'background': '#0020ff36',
        'z-index': '99',
        'text-align': 'center'
    }).appendTo($("body")).append($("<img style='max-height:500px; margin-top:100px' />").attr("src", `/Images/Internal/order-easy-loader.gif`));
}

function HideLoader() {
    $('.oeloader').remove();
}