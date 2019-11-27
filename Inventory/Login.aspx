<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Inventory.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
      <!-- Bootstrap 3.3.5 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/until.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css" />
    <link href="css/customstyles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
        <!---New Login--->
        <div class="limiter1">
            <div class="container-login100">
                <div class="wrap-login100">
                 
                    <div class="login100-pic js-tilt for_rotateimg" data-tilt="">
                           <img src="images/inverexlogo.png" class="forlogoemsClient" alt="img"  />
                        <%--<img src="/Content/App_Images/E-com Logo.png" class="forlogoemsClient" alt="img" />--%>
                    </div>
                    <%--<form runat="server" class="login100-form validate-form">--%>
                    <div class="login100-form validate-form">
                        <div class="login100-pic1 js-tilt" data-tilt="">

                            <img src="images/Inverexcustomercare.png" class="forlogoemsClient" alt="img" />
                        </div>
                        <span class="login100-form-title">Welcome to Payroll
                        </span>
                        <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">
                            <asp:TextBox Type="text" autocomplete="off" class="form-control input100" runat="server" ID="txtUserName" minlength="4" name="UserName" placeholder="Name" required="" value="" ></asp:TextBox>

                            <span class="focus-input100" style="color: #4c3626"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-user" aria-hidden="true" style="color: #4c3626"></i>
                            </span>
                        </div>
                        <div class="wrap-input100 validate-input" data-validate="Password is required">
                            <asp:TextBox class="form-control input100" ID="txtPassword" autocomplete="off" runat="server" name="UserPassword" placeholder="Password" required="" type="password" ></asp:TextBox>

                            <span class="focus-input100" style="color: #4c3626"></span>
                            <span class="symbol-input100">
                                <i class="fa fa-lock" aria-hidden="true" style="color: #4c3626"></i>
                            </span>
                        </div>
                        <div class="container-login100-form-btn">
                            <asp:Button ID="Login" runat="server" class="login100-form-btn" Text="Sign In" OnClick="Login_Click" Style="background-color: #806e44;"></asp:Button>
                           
                        </div>

                        <div class="group">
                            <asp:Label ID="lblErrorMsg" runat="server" Text="Label" Visible="false" CssClass="alert-danger"></asp:Label>
                        </div>

                        <div class="container-login100-form-btn red">
                        </div>
                        <div class="text-center p-t-12">
                            <span class="txt1">Forgot
                            </span>
                            <a class="txt2" href="#">Username / Password?
                            </a>
                        </div>
                        <div class="text-center">
                            <a class="txt2" href="#">Create your Account
                                <i class="fa fa-long-arrow-right m-l-5" aria-hidden="true"></i>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">

                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Verify Your Email Address</h4>
                    </div>
                    <div class="modal-body">

                        <div class="alert alert-success mt-20" role="alert" id="lblSuccess">
                            <strong>Success !</strong> Your email was found in our database
                        </div>
                        <div class="alert alert-info mt-20" role="alert" id="lblPasswordSet">
                            <strong>Success !</strong> Your email was found in our database and your password is already been set, please contact administrator
                        </div>
                        <div class="alert alert-danger mt-20" role="alert" id="lblError">
                            <strong>Error !</strong> Something went wrong, please contact administrator
                        </div>

                        <div id="divEmail">
                            <div class="form-group">
                                <h3 class="fs-18 fw-500 mb-10">Email Address</h3>
                                <input type="email" id="txtEmailNew" class="form-control" placeholder="Enter Your Email Address" />
                            </div>
                            <a id="btnVerify" class="btn btn-success mt-10">Verify</a>
                        </div>
                        <div id="divPassword">
                            <div class="form-group">
                                <h3 class="fs-18 fw-500 mb-10">Your Username</h3>
                                <input type="text" class="form-control" runat="server" id="txtUsernameNew" placeholder="Enter Your Username" onblur="checkUsername()" />
                                <span id="lblUsername"><small style="color: red">This username is already exist</small></span>
                            </div>
                            <div class="form-group">
                                <h3 class="fs-18 fw-500 mb-10">Enter Your Password</h3>
                                <input type="password" class="form-control" runat="server" id="txtPasswordNew" placeholder="Password" />
                            </div>
                            <div class="form-group">
                                <h3 class="fs-18 fw-500 mb-10">Confirm Password</h3>
                                <input type="password" class="form-control" runat="server" id="txtPasswordConfirm" placeholder="Confirm Password" />
                                <span id="lblPasswordMatch"><small style="color: red">Password didn't match</small></span>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <a id="btnSubmit" class="btn btn-primary">Submit</a>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    
    <!----Close Bootstrap Modal ----->

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/tilt.jquery.min.js"></script>
    <script src="js/main.js"></script>
    <script>
        $(window).load()
        {
            //debugger
            var URL = "Promotion_SpCall.aspx";
            $.ajax({
                type: 'POST',
                url: URL,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                //data: "{'Username':'" + username + "'}",
                success: function () {
                    // alert("Check");

                },
                error: function () {
                    //   alert("Check");
                }
            });
        }
        $(document).ready(function () {

            $('#lblSuccess').hide();
            $('#lblError').hide();
            $('#divPassword').hide();
            $('#lblPasswordMatch').hide();
            $('#btnSubmit').hide();
            $('#lblPasswordSet').hide();
            $('#lblUsername').hide();
            $('#btnSubmit').hide();
        });

        $('.js-tilt').tilt({
            scale: 1.1
        });

        $('#btnVerify').click(function () {
            var email = $('#txtEmailNew').val();
            if (email == null || email == 'undefined' || email == '') {
                return false;
            }
            else {
                $.ajax({
                    type: 'POST',
                    url: "login.aspx/CheckEmail",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    data: "{'Email':'" + email + "'}",
                    success: function (result) {
                        var data = JSON.parse(result.d);

                        if (data.PasswordSet == true && data.Status == false) {
                            passwordSet();
                        }
                        else if (data.Status == true && data.PasswordSet == false) {
                            emailFound();
                            $('#txtUsernameNew').val(data.Username);
                        }
                        else {
                            notFound();
                        }
                    },
                    error: function (result) {

                    }
                });
            }
        });

        $('#btnSubmit').click(function () {
            var email = $('#txtEmailNew').val();
            var username = $('#txtUsernameNew').val();
            var password1 = $('#txtPasswordNew').val();
            var password2 = $('#txtPasswordConfirm').val();
            if (password1 != password2) {
                $('#lblPasswordMatch').show();
                return false;
            }
            else {
                $('#lblPasswordMatch').hide();
                $.ajax({
                    type: 'POST',
                    url: "login.aspx/SetPassword",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    data: "{'Email':'" + email + "', 'Password':'" + password1 + "', 'Username' : '" + username + "'}",
                    // data: "{'Email':'" + email + "'}",
                    //data: "{'Email':'" + email + ", Password:''"+password1+"'}",
                    success: function (result) {

                        window.location = "/login.aspx";

                    },
                    error: function (result) {
                    }
                });
            }

        });

        function checkUsername() {
            var userName = $('#txtUsernameNew').val();
            $.ajax({
                type: 'POST',
                url: "login.aspx/CheckUsername",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                data: "{'Username':'" + userName + "'}",
                success: function (result) {
                    if (result.d) {
                        $('#btnSubmit').show();
                        $('#lblUsername').hide();

                    }
                    else {
                        $('#btnSubmit').hide();
                        $('#lblUsername').show();

                    }
                },
                error: function (result) {

                }
            });

        }

        function emailFound() {
            $('#lblSuccess').show();
            $('#divPassword').show();

            $('#lblError').hide();
            $('#divEmail').hide();
            $('#lblPasswordSet').hide();
        }
        function notFound() {
            $('#lblError').show();
            $('#divEmail').show();

            $('#lblSuccess').hide();
            $('#divPassword').hide();

            $('#lblPasswordSet').hide();
        }
        function passwordSet() {
            $('#lblPasswordSet').show();

            $('#divEmail').hide();
            $('#lblError').hide();

            $('#lblSuccess').hide();
            $('#divPassword').hide();
            $('#btnSubmit').hide();
        }
    </script>
    </div>
    </form>
</body>
</html>
