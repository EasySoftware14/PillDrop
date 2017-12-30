$(document).ready(function () {

    $('#order_table tbody').on('click', '.void_action', function (e) {
        var node = stringFormat("tr[oid='{0}']", this.dataset.orderId);
        var rowData = table.fnGetData(node);
        var voidModel = { Id: rowData[6], CpdTypeName: rowData[2], Requestor: rowData[3] };
        $(".void-form-body").empty().append($("#voidForm").tmpl(voidModel));
        initValidation();

        $('#voidDate').datepicker({
            autoclose: true,
            todayHighlight: true,
            maxDate: new Date()
        });
        $("#voidModal").modal({ backdrop: "static", keyboard: false });
    });
    
    $("#order_table tbody").on('click', '#rejectOrder', function (e) {
        var id = this.dataset.orderId;
        $('#orderReject').attr({ oid: id });
        $("#orderRejectModal").modal({ backdrop: "static", keyboard: false });
    });
    $("#orderType select").multipleSelect({
        placeholder: "Order Type"
    });
    
    $('#order_table_wrapper .dataTables_filter input').addClass("input-medium ");
    $('#order_table_wrapper .dataTables_length select').addClass("select2-wrapper span12");
    $(".select2-wrapper").select2({ minimumResultsForSearch: -1 });
    $('#dispatch').click(function () {

        if ($('#courier').val() == '' || $('#waybill').val() == '') {

        }
        else {
            $('#dispatch').text('Submitting');
            $('#dispatch').prop('disabled', true);
            $('#order-dispatch-form').submit();
        }

    });
    $("#order-dispatch-form").formValidationWrapper();
    $('#allocate').click(function () {
        $('#allocate').text('Submitting');
        $('#allocate').prop('disabled', true);
        $('#order-allocate-form').submit();
    });
    $('#confirm').click(function () {
        $('#confirm').text('Submitting');
        $('#confirm').prop('disabled', true);
        $('#order-confirm-form').submit();
    });
    $(".cancel").click(function () {
        $("#confirm-cancel-modal").modal({ backdrop: "static", keyboard: false });
    });
});