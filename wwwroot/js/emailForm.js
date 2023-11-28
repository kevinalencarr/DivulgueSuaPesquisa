document.getElementById('contactEmail').addEventListener('input', function() {
    let input = this;
    if (input.checkValidity()) {
        input.classList.remove('is-invalid');
    } else {
        input.classList.add('is-invalid');
    }
});

$(document).ready(function () {
    $('#checkbox1, #checkbox2').change(function () {
        if ($('#checkbox1').prop('checked') && $('#checkbox2').prop('checked')) {
            $('#submitButton').prop('disabled', false);
        } else {
            $('#submitButton').prop('disabled', true);
        }
    });

    $("#emailForm").submit(function (event) {
        event.preventDefault();

        let name = $("#name").val();
        let lab = $("#lab").val();
        let dept = $("#dept").val();
        let researchTitle = $("#researchTitle").val();
        let researchSummary = $("#researchSummary").val();
        let publicationLink = $("#publicationLink").val();
        let contactPhone = $("#contactPhone").val();
        let contactEmail = $("#contactEmail").val();

        $.ajax({
            type: "POST",
            url: "/Email/SendEmail",
            contentType: "application/json",
            data: JSON.stringify({
                subject: researchTitle,
                name: name,
                lab: lab,
                dept: dept,
                researchTitle: researchTitle,
                researchSummary: researchSummary,
                publicationLink: publicationLink,
                contactPhone: contactPhone,
                contactEmail: contactEmail
            }),
            success: function () {
                $('#successModal').modal('show');
            },
            error: function () {
                $('#errorModal').modal('show');
            }
        });
    });
});