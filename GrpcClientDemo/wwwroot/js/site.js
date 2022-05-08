function loadAuthors() {
    $.ajax({
        url: "/api/v2/author",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var output = '';
            $.each(result, function (key, item) {
                output += '<tr>';
                output += '<td>' + item.id + '</td>';
                output += '<td>' + item.name + '</td>';
                output += `<td><a href="#" class="btn btn-warning btnEditAuthor" data-id='` + item.id + `'>Edit</a> |
                        <a href="#" class="btn btn-danger btnDeleteAuthor" data-id='`+ item.id + `'>Delete</a></td>`;
                output += '</tr>';
            });
            $('.tbody').html(output);
        },
        error: function (message) {
            console.log(message.responseText);
        }
    });
}

//#######################################

$(document).on("click", "#btnAddNewAuthor", function (e) {
    setUpModal();
});

//#######################################

$(document).on("click", "a.btnEditAuthor", function (e) {
    e.preventDefault();
    //var id2 = $(this).data('id');
    let id = $(this).attr("data-id");
    setUpModal(id, 'edit');
});

//#######################################
$(document).on("click", "a.btnDeleteAuthor", function (e) {
    e.preventDefault();
    if (confirm("Are you sure?")) {
        let id = $(this).attr("data-id");
        $.ajax({
            url: "/api/v2/author/" + id,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (response) {
                //alert(response);
                loadAuthors();
            },
            error: function (message) {
                console.log(message.responseText);
            }
        });
    }
});


//#######################################

function setUpModal(id = 0, mode = "add") {
    if (mode == "add") {
        $('.add_hide_id').hide();
        $('#authorModal').modal('show');
    } else {
        $('.add_hide_id').show();
        $('#Id').attr('disabled', 'disabled');
        $('form input').css('border-color', 'grey');
        $('#authorModal h4').text('Edit author');
        $.ajax({
            url: "/api/v2/author/" + id,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                debugger
                $('#Id').val(result.id);
                $('#Name').val(result.name);
                $('#authorModal').modal('show');
            },
            error: function (message) {
                console.log(message.responseText);
            }
        });
    }
    return false;
}


//#######################################

$(document).on("click", "#btnSubmitForm", function (e) {
    e.preventDefault();
    let id = $("#Id").val();
    let validate = id > 0 ? validateForm('edit') : validateForm('add');
    if (!validate) return;
    var authorModel = {
        id: "-1",
        name: $('#Name').val()
    }
    let verbType = 'POST';
    if (id) {
        authorModel.id = id;
        verbType = 'PUT'
    }

    $.ajax({
        url: "/api/v2/author",
        type: verbType,
        data: JSON.stringify(authorModel),
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            clearStuff();
            loadAuthors();
        },
        error: function (message) {
            console.log(message.responseText);
        }
    });


});

//#######################################
//#######################################

function validateForm(mode = 'add') {
    var isValid = true;

    if (mode == 'edit') {
        if ($('#Id').val().trim() == "") {
            $('#Id').css('border-color', '#c00');
            isValid = false;
        }
        else {
            $('#Name').css('border-color', 'grey');
        }
    }

    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', '#c00');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'grey');
    }

    return isValid;
}

function clearStuff() {
    $('#authorModal form').trigger("reset");
    //$('#authorModal h4').text('Add Author');
    $('#authorModal').modal('hide');
}

$(document).on("click", ".btnCloseModal", function (e) {
    clearStuff();
});


loadAuthors();