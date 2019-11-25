var columns;
$(function () {
    initializeDatatable();

    $('.name').editable({
        type: 'text',
        title: 'Name',
        mode: 'inline',
        success: function (response, newValue) {
            let phonebookId = $(this).attr('data-phonebookid');

            if (newValue == '') {
                toastr.error('Name is required')

                return false;
            }

            $.post('/UpdatePhonebook/UpdateName', { phonebookId: phonebookId, name: newValue });
            toastr.success('Name updated')
        }
    });
});

$('.add_new_phone_book').click(function () {
    $.get('/ShowPhonebook/NewPhoneBook').done(function (data) {
        $.confirm({
            title: 'New Phonebook',
            content: data,
            buttons: {
                cancel: {
                    btnClass: 'btn btn-danger'
                },
                confirm: {
                    btnClass: 'btn btn-primary',
                    action: function () {
                        if (!$('#validatePhonebook').valid()) {
                            return false;
                        }

                        $.post('/CreatePhonebook/Create', { name: $('.phone_book_name').val() }).done(function () {
                            window.location.reload();

                            toastr.success('Entry created')
                        });
                    }
                }
            }
        });
    });
});

$('body').on('click', '.delete_phone_book', function () {
    var $tr = $(this).closest('tr');
    var phonebookId = $(this).attr('data-phonebookid');

    $.confirm({
        title: 'Confirm delete',
        content: 'Are you sure you would like to delete this phone book entry?',
        buttons: {
            cancel: {
                btnClass: 'btn btn-danger'
            },
            confirm: {
                btnClass: 'btn btn-primary',
                action: function () {
                    $.post('/DeletePhonebook/Delete', { phonebookId: phonebookId }).done(function () {
                        $tr.remove();

                        toastr.success('Entry deleted')
                    });
                }
            }
        }
    });
});

function initializeDatatable() {
    $('.phone_book_table').DataTable({
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