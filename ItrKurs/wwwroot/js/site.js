$('#fullCheckBox').click(function () {
    if ($(this).is(':checked')) {
        $('input:checkbox').prop('checked', true);
    } else {
        $('input:checkbox').prop('checked', false);
    }
});

$('input:checkbox').click(function () {
    if ($(this).is(':checked')) { }
    else { $('#fullCheckBox').prop('checked', false); }
});

var id = [];
var bitmask;
function CheckedID()
{
    var object = $('td input[type ="checkbox"]:checked');

    $.each(object, function (index, value) {
        console.log('Индекс:' + index + '; Значение' + value.id);
        id[index] = value.id;
    });

}

var str;
function comment(idTextArea, id) {
    str = document.getElementById(idTextArea).value;
    $.ajax({
        url: '/Collection/Comment',
        type: 'POST',
        data: { id: id, str: str},
        success: function (result) {
            if (result == 1) {
                window.location = '/Collection/Details/'+id;
            }
            else {
                alert("Error");
            }
        }
    });
}

function ShowField(bitM) {
    boolMask(bitM)
    document.getElementById("Bitmask").value = bitM;
}

function ShowFieldTable(bitM) {
    for (var i = 0; i < 10; i++) {
        var tmp = 1 << i;
        if ((bitM & tmp) !== tmp) {
            document.getElementById(i).style.display = 'none';
            document.getElementById(i + 'a').style.display = 'none';}            
    }
}

function boolMask(bitM) {
    
    for (var i = 0; i < 10; i++) {
        var tmp = 1 << i;
        if((bitM & tmp) == tmp)
        document.getElementById(i).style.display = 'block';
    }
}

function toggle(element, id) {
    if (element.checked) {
        bitmask |= (1 << element.id);
        document.getElementById(id).style.display = 'block';
    }

    else
    {
        document.getElementById(id).style.display = 'none';
        bitmask &= ~(1 << element.id);
    }
    document.getElementById("Bitmask").value = bitmask;   
}

$(document).ready(function () {

    $("#progress").hide();

    $("#fileBasket").on("dragenter", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });

    $("#fileBasket").on("dragover", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
    });

    $("#fileBasket").on("drop", function (evt) {
        evt.preventDefault();
        evt.stopPropagation();
     });
});



$('#buttonDelete').click(function () {
    CheckedID();
    $.ajax({
        url: '/Users/Delete',
        type: 'POST',
        data: { id: id },
        success: function (result) {
            if (result == 1) {
                window.location = '/Users/';
            }
            else {
                alert("Error delete");
            }
        }
    });
});


$('#buttonBlock').click(function () {
    CheckedID();
    $.ajax({
        url: '/Users/EditStatus',
        type: 'POST',
        data: { id: id, block: "Block" },
        success: function (result) {
            if (result == 1) {
                window.location = '/Users/';
            }
            else {
                alert("Error status");
            }
        }
    });
});



$('#buttonUnblock').click(function () {
    CheckedID();
    $.ajax({
        url: '/Users/EditStatus',
        type: 'POST',
        data: { id: id, block: "Unblock" },
        success: function (result) {
            if (result == 1) {
                window.location = '/Users/';
            }
            else
            {
                alert("Error status");
            }
        }
    });
});


$("#fileBasket").on("drop", function (evt) {
    evt.preventDefault();
    evt.stopPropagation();
    var files = evt.originalEvent.dataTransfer.files;
    var fileNames = "";
    if (files.length > 0) {
        fileNames += "Uploading <br/>"
        for (var i = 0; i < files.length; i++) {
            fileNames += files[i].name + "<br />";
        }
    }
    $("#fileBasket").html(fileNames)

    var data = new FormData();
    for (var i = 0; i < files.length; i++) {
        data.append(files[i].name, files[i]);
    }
    $.ajax({
        type: "POST",
        url: "/Collection/UploadFiles",
        contentType: false,
        processData: false,
        data: data,
        success: function (message) {
            document.getElementById("ImgSrc").value = message;
            $("#fileBasket").html("Upload successful");
        },
        error: function () {
            $("#fileBasket").html
                ("There was error uploading files!");
        },
        beforeSend: function () {
            $("#progress").show();
        },
        complete: function () {
            $("#progress").hide();
        }
    });
});