var columns;
var entries;
$(function () {
    initializeDatatable();

    $('.name, .number').editable({
        type: 'text',
        title: 'Name',
        mode: 'inline',
        validate: function (value) {

        },
        success: function (response, newValue) {
            let entryId = $(this).attr('data-entryid');
            let index = $(this).attr('data-index');
            let oldValue = $(this).attr('data-oldvalue');
            let telRegex = new RegExp('(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{4}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})')

            if ($(this).attr('class').indexOf("name") == 0) {
                
                if (newValue == '') {
                    toastr.error('Name is required')

                    return false;
                }
                else if (newValue.length > 50) {
                    toastr.error('Please enter a name that does not exceed 50 characters');

                    return false;
                }

                $.post('/UpdateEntry/UpdateName', { entryId: entryId, name: newValue });
                toastr.success('Name updated')
            }
            else {
                if (!telRegex.test(newValue) || newValue.length > 14) {
                    toastr.error('Please enter a valid phone number eg. +2781138145');

                    $(`.number-${index}`).editable('setValue', oldValue, true);

                    return false;
                }
                else {
                    $.post('/UpdateEntry/UpdatePhoneNumber', { entryId: entryId, phoneNumber: newValue });

                    $(`.number-${index}`).attr('data-oldvalue', newValue);

                    toastr.success('Phone number updated')
                }
            }
        }
    });
});



$('body').on('click', '.delete_entry', function () {
    var $tr = $(this).closest('tr');
    var entryId = $(this).attr('data-entryid');

    $.confirm({
        title: 'Confirm delete',
        content: 'Are you sure you would like to delete this entry?',
        buttons: {
            cancel: {
                btnClass: 'btn btn-danger'
            },
            confirm: {
                btnClass: 'btn btn-primary',
                action: function () {
                    $.post('/DeleteEntry/Delete', { entryId: entryId }).done(function () {
                        $tr.remove();

                        toastr.success('Entry deleted')
                    });
                }
            }
        }
    });
});

$('.cancel').click(function () {
    window.location = "/ShowPhonebook/Index";
});

function initializeDatatable() {
    $('.entry_table').DataTable({
        dom: 'Zlfrtip',
        "stateSave": true,
        "columnDefs":
            [{
                "targets": 'no-sort',
                "orderable": false,
            }],
        "order": [[1, "asc"]],
        stateSave: true
    });
}