let toDelete = 0;
function showPopup(id, popupId) {
    toDelete = id;
    show(popupId)
}
function hidePopup() {
    $('.confirmation').each(function () {
        if (!$(this).hasClass('hidden')) {
            $(this).addClass("hidden");
        }
    });
    toDelete = -1;
}
function hide(id) {
    let element = $(id)
    if (!element.hasClass('hidden')) {
        element.addClass('hidden')
    }
}
function show(id) {
    let element = $(id)
    if (element.hasClass('hidden')) {
        element.removeClass('hidden')
    }
}
function deleteAddress() {
    $.ajax({
        type: "Post",
        url: '/Addresses/Delete/' + String(toDelete),       
        success: function (result) {
            if (result == 'success') {
                history.go(0);
            }
            else {                
                alert(result)
                history.go(0);
            }
        },
        error: function (e) {
            console.log(e)
        }
    });
}
function deletePerson() {
    $.ajax({
        type: "Post",
        url: '/People/Delete/' + String(toDelete),        
        success: function (result) {
            if (result == 'success') {
                history.go(0);
            }
            else {               
                alert(result)
                history.go(0);
            }
        },
        error: function (e) {
            console.log(e)
        }
    });
}
function deleteDiary() {
    $.ajax({
        type: "Post",
        url: '/Diaries/Delete/' + String(toDelete),     
        success: function (result) {
            if (result == 'success') {
                history.go(0);
            }
            else {                
                alert(result)
                history.go(0);
            }
        },
        error: function (e) {
            console.log(e)
        }
    });
}