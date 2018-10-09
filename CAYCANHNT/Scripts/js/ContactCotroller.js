var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#txtusername').val();
            var email = $('#txtemail').val();
            var title = $('#txttitle').val();
            var detail = $('#txtdetail').val();

            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    email: email,
                    title: title,
                    detail: detail
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Gửi thành công!');
                        $('#txtusername').val('');
                        $('#txtemail').val('');
                        $('#txttitle').val('');
                        $('#txtdetail').val('');
                    }
                }
            });
        });
    }
}
contact.init();