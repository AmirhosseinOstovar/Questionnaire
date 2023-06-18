
function popupr(id) {
    hrb_alert(
        [
            'info', //['danger','success','warning','info']
            'ساخت سوال جدید',
            '',
            'sendCancel', //['ok','okCancel','sendCancel','delCancel','cancel']
            'ارسال کن',
            'کنسل',
            '<label for="Title">عنوان سوال را وارد کنید</label>  <input id="title" type="text"  placeholder="عنوان" name="Title" required><select name="questionType" id="type" onchange="select()"> <option value="">نوع سوال را انتخاب کنید</option> <option value="0">چند گزینه ای</option>    <option value="1">متنی</option>  <option value="2">عددی</option>  <option value="3">فایل</option> </select><div id="ismulty"></div> <div id="textBoxContainer"></div>'

            //html Content
        ], function hrb_success(e) { // Run in button Ok
            var data = $(".frm_hrb_alert_Send_Data").serialize();
            /* alert(id);*/
            var inputElements = document.querySelectorAll('input[id="textBox"]');

            var inputValues = [];
            for (var i = 0; i < inputElements.length; i++) {
                var value = inputElements[i].value;
                inputValues.push(value);
            }
            //console.log(inputValues);
            var model = {};
            model.Title = $("#title").val();
            model.CategoryId = id;
            model.questionType = $("#type").val();

            $.ajax({
                type: 'post',
                data: {
                    model,
                    multy: inputValues
                },
                dataType: 'json',
                url: '/AddQuestion',
                success: function (res) {
                    /* alert(res);*/
                    if (res) {
                        setTimeout(function () {

                            hrb_alert(
                                [
                                    'success', //['danger','success','warning','info']
                                    'عملیات موفق!',
                                    'سوال شماثبت شد.',
                                    'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                                    'باشه',
                                ], function hrb_success(e) { // Run in button Ok
                                    // alert('Success !');
                                }, function hrb_cancel(e) { // Run in button Ok
                                    // alert('hamidreza biglari')
                                }
                            );
                        }, 200);

                        $.ajax({
                            url: "/Question/GetQuestion",
                            type: "POST",
                            cashe: false,
                            data: {
                                id: id
                            },
                            success: function (response) {
                                // Handle the success response

                                //console.log(response);
                                $("#Question").html(response);
                                //HideLoading()
                            },
                            error: function (xhr, status, error) {
                                // Handle the error response
                                console.log(error);
                            }
                        });

                    } else {
                        setTimeout(function () {

                            hrb_alert(
                                [
                                    'danger', //['danger','success','warning','info']
                                    'عملیات ناموفق!',
                                    'خطایی رخ داده دوباره تلاش کنید.',
                                    'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                                    'باشه',
                                ], function hrb_success(e) { // Run in button Ok
                                    // alert('Success !');
                                }, function hrb_cancel(e) { // Run in button Ok
                                    // alert('hamidreza biglari')
                                }
                            );
                        }, 200);

                    }

                    //alert(result); 

                    //$.each(result, function (index, value) {
                    //    $("#SelectProviance").append(`<option value=${value.id}>${value.title}</option>`);
                    //});
                }
            });

        }, function hrb_cancel(e) { // Run in button Ok
            // alert('hamidreza biglari')
        }
    );
}

function select() {
    debugger;
    var Id = $("#type").val();
    var ismultyElement = document.getElementById("ismulty");
    if (Id == 0) {
        var button = document.createElement("a");
        button.textContent = "برای ساخت گزینه کلیک کنید ";
        button.style.color = "white";
        button.style.backgroundColor = "blue";
        button.style.fontSize = "16px";
        button.addEventListener("click", createTextBox);
        ismultyElement.appendChild(button);
    } else {
        ismultyElement.innerHTML = '';
        var textBoxContainer = document.getElementById("textBoxContainer");
        textBoxContainer.innerHTML = '';
    }
    //$("#SelectProviance").html('<option value="0">Web.Resourse.Resource.SelectRegion</option>');
    //$("#SelectCity").html('<option value="0">Web.Resourse.Resource.SelectCity </option>');

    //$.ajax({
    //    type: 'post',
    //    data: { id: Id },
    //    dataType: 'json',
    //    url: '/culture/Cookie/OnGetProviance',
    //    success: function (result) {
    //        $.each(result, function (index, value) {
    //            $("#SelectProviance").append(`<option value=${value.id}>${value.title}</option>`);
    //        });
    //    }
    //});
}
function createTextBox() {
    var textBoxCount = 0;
    textBoxCount++;

    var textBoxContainer = document.getElementById("textBoxContainer");
    var newTextBox = document.createElement("input");
    newTextBox.type = "text";
    newTextBox.id = "textBox";
    newTextBox.name = "multipleOptions";
    textBoxContainer.appendChild(newTextBox);
}

function CreatcategoryQuestion() {
    hrb_alert(
        [
            'info', //['danger','success','warning','info']
            'ساخت پرسشنامه جدید ',
            '',
            'sendCancel', //['ok','okCancel','sendCancel','delCancel','cancel']
            'ارسال کن',
            'کنسل',
            '<label for="Title">عنوان پرسشنامه را وارد کنید</label>  <input id="titlecategory" type="text"  placeholder="عنوان" name="Title" required>'

            //html Content
        ], function hrb_success(e) { // Run in button Ok
            var title = $("#titlecategory").val();

            $.ajax({
                type: 'post',
                data: {
                    Title: title
                },
                dataType: 'json',
                url: '/Home/AddCategoryQuestion',
                success: function (res) {
                    /* alert(res);*/
                    if (res) {
                        $.ajax({
                            url: "/Home/GetAllCategoryQuestion",
                            type: "POST",
                            cashe: false,
                            success: function (response) {
                                // Handle the success response

                                console.log(response);
                                $("#Category").html(response);
                                //HideLoading()
                            },
                            error: function (xhr, status, error) {
                                // Handle the error response
                                console.log(error);
                            }
                        });
                        setTimeout(function () {

                            hrb_alert(
                                [
                                    'success', //['danger','success','warning','info']
                                    'عملیات موفق!',
                                    'پرسشنامه ی شماثبت شد.',
                                    'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                                    'باشه',
                                ], function hrb_success(e) { // Run in button Ok
                                    // alert('Success !');
                                }, function hrb_cancel(e) { // Run in button Ok
                                    // alert('hamidreza biglari')
                                }
                            );
                        }, 200);
                    } else {
                        setTimeout(function () {

                            hrb_alert(
                                [
                                    'danger', //['danger','success','warning','info']
                                    'عملیات ناموفق!',
                                    'خطایی رخ داده دوباره تلاش کنید.',
                                    'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                                    'باشه',
                                ], function hrb_success(e) { // Run in button Ok
                                    // alert('Success !');
                                }, function hrb_cancel(e) { // Run in button Ok
                                    // alert('hamidreza biglari')
                                }
                            );
                        }, 200);
                    }
                }
            });

        }, function hrb_cancel(e) { // Run in button Ok
            // alert('hamidreza biglari')
        }
    );
}
function EditeQuestion(id) {

    $.ajax({
        url: "/Home/EditeCategory",
        type: "POST",
        cashe: false,
        data: { id: id },
        success: function (res) {
            var response = JSON.parse(res);
            console.log(response);
            hrb_alert(
                [
                    'info', //['danger','success','warning','info']
                    'ویرایش پرسشنامه جدید ',
                    '',
                    'sendCancel', //['ok','okCancel','sendCancel','delCancel','cancel']
                    'ارسال کن',
                    'کنسل',
                    `<label for="Title">عنوان پرسشنامه را وارد کنید</label>  <input id="titlecategory" type="text" value="${response.Title}"  placeholder="عنوان" name="Title" required>   <label for="Title">برای پاسخ به سوال کلیک کنید</label>   <a href="/ResponseQuestions/${response.Url}">URL</a>`

                    //html Content
                ], function hrb_success(e) {
                    // Run in button Ok
                    $.ajax({
                        url: "/Home/Edite",
                        type: "POST",
                        cashe: false,
                        data: {
                            id: id,
                            title: $("#titlecategory").val()
                        },
                        success: function (res) {
                            if (res) {


                                $.ajax({
                                    url: "/Home/GetAllCategoryQuestion",
                                    type: "POST",
                                    cashe: false,
                                    success: function (response) {
                                        // Handle the success response

                                        hrb_alert(
                                            [
                                                'success', //['danger','success','warning','info']
                                                'عملیات موفق!',
                                                '',
                                                'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                                                'باشه',
                                                //html Content
                                            ], function hrb_success(e) { // Run in button Ok

                                            }, function hrb_cancel(e) { // Run in button Ok
                                                // alert('hamidreza biglari')
                                            }
                                        );
                                        $("#Category").html(response);
                                        //HideLoading()
                                    },
                                    error: function (xhr, status, error) {
                                        // Handle the error response
                                        console.log(error);
                                    }
                                });
                            }
                            // Handle the success response
                        },
                        error: function (xhr, status, error) {
                            // Handle the error response
                            console.log(error);
                        }
                    });
                }, function hrb_cancel(e) { // Run in button Ok
                    // alert('hamidreza biglari')
                }
            );
            // Handle the success response
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.log(error);
        }
    });




}


function DelitQuestion(id) {
    hrb_alert(
        [
            'danger', //['danger','success','warning','info']
            'مطمئنید که میخواهید حذف کنید ؟!',
            'در صورت تایید این مطلب به صورت کامل حذف خواهد شد',
            'delCancel', //['ok','okCancel','sendCancel','delCancel','cancel']
            'حذفش کن',
            'کنسل',
        ], function hrb_success(e) { // Run in button Ok
            setTimeout(function () {
                $.ajax({
                    url: "/Home/Delit",
                    type: "POST",
                    cashe: false,
                    data: { id: id },
                    success: function (res) {

                        hrb_alert(
                            [
                                'success', //['danger','success','warning','info']
                                'عملیات موفق!',
                                'مطلب مورد نظر با موفقیت حذف شد',
                                'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                                'باشه',

                            ], function hrb_success(e) { // Run in button Ok
                                // alert('hamidreza biglari')
                            }, function hrb_cancel(e) { // Run in button Ok
                                // alert('hamidreza biglari')
                            }
                        );

                        $.ajax({
                            url: "/Home/GetAllCategoryQuestion",
                            type: "POST",
                            cashe: false,
                            success: function (response) {
                                // Handle the success response
                                $("#Category").html(response);
                                //HideLoading()
                            },
                            error: function (xhr, status, error) {
                                // Handle the error response
                                console.log(error);
                            }
                        });
                        // Handle the success response
                    },
                    error: function (xhr, status, error) {
                        // Handle the error response
                        console.log(error);
                    }
                });
            }, 200);
        }, function hrb_cancel(e) { // Run in button Ok
            // alert('hamid')
        }
    );

}

function EditeQuestionmodel(id) {
    var questionid = id;
    $.ajax({
        url: "/Question/EditeQuestion",
        type: "POST",
        cashe: false,
        data: { id: id },
        success: function (res) {
            var response = JSON.parse(res);
            console.log(response);
            if (response.MultipleOptionsResponses != null) {
                var multyy = response.MultipleOptionsResponses;
                multyy.forEach(function (multy) {
                    var textBoxContainer = document.getElementById("textBoxContainer");
                    var newTextBox = document.createElement("input");
                    newTextBox.type = "text";
                    newTextBox.id = "textBox";
                    newTextBox.name = "multipleOptions";
                    newTextBox.value = multy.Title;
                   textBoxContainer.appendChild(newTextBox);
                });


            }
            hrb_alert(
                [
                    'info', //['danger','success','warning','info']
                    'ویرایش سوال ',
                    '',
                    'sendCancel', //['ok','okCancel','sendCancel','delCancel','cancel']
                    'ارسال کن',
                    'کنسل',
                    `<label for="Title">عنوان سوال را وارد کنید</label> <input id="questioid" type="hidden" value="${response.id}"> <input id="title" type="text"  placeholder="عنوان" name="Title" value="${response.Title}" required><select name="questionType" id="type" onchange="select()"> <option value=""></option> <option value="0">چند گزینه ای</option>    <option value="1">متنی</option>  <option value="2">عددی</option>  <option value="3">فایل</option> </select><div id="ismulty"></div> <div id="textBoxContainer"></div>`

                    //html Content
                ]
                ,
                function hrb_success(e) {
                    var model = {};
                    model.Title = $("#title").val();
                    model.QuestionId = $("#questioid").val();
                    model.questionType = $("#type").val();
                    // Run in button Ok
                    $.ajax({
                        url: "/Question/Edite",
                        type: "POST",
                        cashe: false,
                        data: {
                            model
                        },
                        success: function (res) {
                            if (res) {
                                location.reload();
                            }
                            // Handle the success response
                        },
                        error: function (xhr, status, error) {
                            // Handle the error response
                            console.log(error);
                        }
                    });
                }, function hrb_cancel(e) { // Run in button Ok
                    // alert('hamidreza biglari')
                }
            );
            // Handle the success response
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.log(error);
        }
    });




}
function DelitQuestionmodel(id,catid) {
    hrb_alert(
        [
            'danger', //['danger','success','warning','info']
            'مطمئنید که میخواهید حذف کنید ؟!',
            'در صورت تایید این مطلب به صورت کامل حذف خواهد شد',
            'delCancel', //['ok','okCancel','sendCancel','delCancel','cancel']
            'حذفش کن',
            'کنسل',
        ], function hrb_success(e) { // Run in button Ok
            setTimeout(function () {
                $.ajax({
                    url: "/Question/Delit",
                    type: "POST",
                    cashe: false,
                    data: { id: id },
                    success: function (res) {

                        hrb_alert(
                            [
                                'success', //['danger','success','warning','info']
                                'عملیات موفق!',
                                'مطلب مورد نظر با موفقیت حذف شد',
                                'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                                'باشه',

                            ], function hrb_success(e) { // Run in button Ok
                                // alert('hamidreza biglari')
                            }, function hrb_cancel(e) { // Run in button Ok
                                // alert('hamidreza biglari')
                            }
                        );

                        $.ajax({
                            url: "/Question/GetQuestion",
                            type: "POST",
                            cashe: false,
                            data: { id: catid },
                            success: function (response) {
                                // Handle the success response
                                $("#Question").html(response);
                                //HideLoading()
                            },
                            error: function (xhr, status, error) {
                                // Handle the error response
                                console.log(error);
                            }
                        });
                        // Handle the success response
                    },
                    error: function (xhr, status, error) {
                        // Handle the error response
                        console.log(error);
                    }
                });
            }, 200);
        }, function hrb_cancel(e) { // Run in button Ok
            // alert('hamid')
        }
    );

}
function CreatResponse(id) {
    $.ajax({
        url: "/Question/Response",
        type: "POST",
        cashe: false,
        data: { QuestionId: id },
        success: function (response) {
            // Handle the success response
            $("#Question").html(response);
            //HideLoading()
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.log(error);
        }
    });


  
}

function AddresponseForm() {
    var model = {};
    var ans = $("#answer").val();
    var na = $("#name").val();
    var Fami = $("#family").val();
    var Questi = $("#questionId").val();
    console.log(model);
    $.ajax({
        url: "/Question/ResponseAdd",
        type: "POST",
        data: {
            Answer: ans,
            Name: na,
            Family: Fami,
            QuestionId: Questi

        },
        dataType: 'json',
        success: function (response) {
            // Handle the success response
            document.getElementById("ResponseForm").reset();
            if (response) {
                hrb_alert(
                    [
                        'success', //['danger','success','warning','info']
                        'عملیات موفق!',
                        '',
                        'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                        'باشه',

                    ], function hrb_success(e) { // Run in button Ok
                        // alert('hamidreza biglari')
                    }, function hrb_cancel(e) { // Run in button Ok
                        // alert('hamidreza biglari')
                    }
                );
            }
            else {
                hrb_alert(
                    [
                        'danger', //['danger','success','warning','info']
                        'عملیات ناموفق!',
                        'دوباره تلاش کنید',
                        'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                        'باشه',

                    ], function hrb_success(e) { // Run in button Ok
                        // alert('hamidreza biglari')
                    }, function hrb_cancel(e) { // Run in button Ok
                        // alert('hamidreza biglari')
                    }
                );
            }
            //HideLoading()
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.log(error);
        }
    });



}

function Result() {
    $.ajax({
        url: "/Home/CategoryQuestionList",
        type: "POST",
        success: function (response) {
            // Handle the success response
            $("#body").html(response);
        
            //HideLoading()
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.log(error);
        }
    });



}
function Myquestion() {
    $.ajax({
        url: "/Home/MyQuestions",
        type: "POST",
        success: function (response) {
            // Handle the success response
            $("#body").html(response);

            //HideLoading()
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.log(error);
        }
    });



}
function Responses(id) {
    $.ajax({
        url: "/Home/GetResponse",
        type: "POST",
        data: { CategoryId :id},
        success: function (response) {
            // Handle the success response
            $("#body").html(response);

            //HideLoading()
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.log(error);
        }
    });
}
function ShowResponses(id) {
    $.ajax({
        url: "/Home/GetDetailResponse",
        type: "POST",
        data: { ResponseId: id },
        success: function (response) {
            var response = JSON.parse(response);
            hrb_alert(
                [
                    'info', //['danger','success','warning','info']
                    'پاسخ کاربر:',
                    `${response.Answer}`,
                    'ok', //['ok','okCancel','sendCancel','delCancel','cancel']
                    'باشه',
                    //html Content
                ], function hrb_success(e) { // Run in button Ok

                }, function hrb_cancel(e) { // Run in button Ok
                    // alert('hamidreza biglari')
                }
            );

          
            // Handle the success response
         

            //HideLoading()
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.log(error);
        }
    });
}