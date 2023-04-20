<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.Login" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <link rel="shortcut icon" href="images/perzonalizadas/login/images.jpg" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Control - Entrar</title>

    <!-- Bootstrap -->
    <link href="bootstrap-5.0.2-dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <!-- Font Awesome -->
    
    <link href="css/personalizados/login/style.css" rel="stylesheet" />
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />    
    <link href="css/personalizados/errors.css" rel="stylesheet" />
</head>
<body >    
    <form id="formLogin" runat="server">
    <section class="vh-100">
        <div class="container-fluid h-custom">
            <div class="row d-flex justify-content-center align-items-center h-100">
                 <%--<div class="col-md-9 col-lg-6 col-xl-5" >                   
                     <img src="images/perzonalizadas/login/images.jpg" width="450" height="450" />
                </div>--%>
                <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">                    
                    <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
                        <p class="lead fw-normal mb-0 me-3">Iniciar sesión</p>
                        <button type="button" class="btn btn-primary btn-floating mx-1">
                            <i class="fab fa-facebook-f"></i>
                        </button>
                        <button type="button" class="btn btn-primary btn-floating mx-1">
                            <i class="fab fa-twitter"></i>
                        </button>
                        <button type="button" class="btn btn-primary btn-floating mx-1">
                            <i class="fab fa-linkedin-in"></i>
                        </button>
                    </div>
                    <div class="divider d-flex align-items-center my-4">
                        <p class="text-center fw-bold mx-3 mb-0">Con</p>
                    </div>
                    <span class="invalid-feedback" role="alert" style="display:inline;">
                            <strong style=" font-family:Verdana">
                                <asp:Label Font-Names="Verdana" ID="lblEmailNonexistent" runat="server"></asp:Label>
                            </strong>
                             <strong style=" font-family:Verdana">
                                <asp:Label Font-Names="Verdana" ID="lblBlockedAccount" runat="server"></asp:Label>
                            </strong>
                        </span>
                     <AnonymousTemplate>
                        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate"  CssClass="loginWhite">
                            <LayoutTemplate>
                                <!-- Email input -->
                                <div class="form-outline mb-4">
                                    <div class="row">
                                        <asp:RequiredFieldValidator ID="UserNameRequired" CssClass="errorMessage" runat="server" ControlToValidate="UserName" ErrorMessage="Usuario obligatorio." ToolTip="Usuario obligatorio." ValidationGroup="ctl00$Login1">Usuario obligatorio.</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="input-group w-70">
                                        <span class="input-group-text" id="basic-addon2">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-person-circle" viewBox="0 0 16 16">
                                                <path d="M11 6a3 3 0 1 1-6 0 3 3 0 0 1 6 0z"></path>
                                                <path fill-rule="evenodd" d="M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm8-7a7 7 0 0 0-5.468 11.37C3.242 11.226 4.805 10 8 10s4.757 1.225 5.468 2.37A7 7 0 0 0 8 1z"></path>
                                            </svg>
                                        </span>                                           
                                        <asp:TextBox CssClass="form-control form-control-lg" aria-label="Input group example" placeholder="Nombre de usuario" ID="UserName" runat="server"></asp:TextBox>
                                    </div>                                      
                                    <div class="row">
                                        <label class="form-label" for="form3Example3">Usuario</label>
                                    </div>                                                                                
                                </div>
                                <!-- Password input -->
                                <div class="form-outline mb-3">
                                    <div class="row">
                                        <asp:RequiredFieldValidator ID="PasswordRequired" CssClass="errorMessage" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="ctl00$Login1">La contraseña es obligatoria.</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="input-group w-70">
                                        <span class="input-group-text" id="basic-addon1">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-lock-fill" viewBox="0 0 16 16">
                                                <path d="M8 1a2 2 0 0 1 2 2v4H6V3a2 2 0 0 1 2-2zm3 6V3a3 3 0 0 0-6 0v4a2 2 0 0 0-2 2v5a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2z"></path>
                                            </svg>
                                        </span>                                            
                                        <asp:TextBox CssClass="form-control form-control-lg" aria-label="Input group example"  placeholder="Contraseña" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <span style="position: absolute;right:10px;top:15px">
                                            <svg style="display:block" id="slash" xmlns="http://www.w3.org/2000/svg" width="16" onclick="hideshow('Login1_Password','slash','eye')" height="16" fill="currentColor" class="bi bi-eye-fill" viewBox="0 0 16 16">
                                              <path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"/>
                                              <path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z"/>
                                            </svg>
		            	                </span>
                                        <span style="position: absolute;right:10px;top:15px">
                                            <svg style="display:none" id="eye" xmlns="http://www.w3.org/2000/svg" width="16" onclick="hideshow('Login1_Password','slash','eye')" height="16" fill="currentColor" class="bi bi-eye-slash-fill" viewBox="0 0 16 16">
                                                <path d="m10.79 12.912-1.614-1.615a3.5 3.5 0 0 1-4.474-4.474l-2.06-2.06C.938 6.278 0 8 0 8s3 5.5 8 5.5a7.029 7.029 0 0 0 2.79-.588zM5.21 3.088A7.028 7.028 0 0 1 8 2.5c5 0 8 5.5 8 5.5s-.939 1.721-2.641 3.238l-2.062-2.062a3.5 3.5 0 0 0-4.474-4.474L5.21 3.089z"/>
                                                <path d="M5.525 7.646a2.5 2.5 0 0 0 2.829 2.829l-2.83-2.829zm4.95.708-2.829-2.83a2.5 2.5 0 0 1 2.829 2.829zm3.171 6-12-12 .708-.708 12 12-.708.708z"/>
                                            </svg>
		            	                </span>
                                    </div>                                        
                                    <div class="row">
                                        <label class="form-label" for="form3Example4">Contraseña</label>
                                    </div>
                                </div> 
                               <%-- <div clas="d-flex justify-content-between align-items-center">                                    
                                    <div class="form-check mb-0">                                        
                                        <input checked style="padding:10px" class="form-check-input me-2" name="checkRemember" type="checkbox"  id="form2Example3" />
                                        <label class="form-check-label" for="form2Example3">
                                          Recordar cuenta
                                        </label>
                                    </div>                                       
                                </div>--%>
                                <div>
                                <div  class="text-center text-lg-start mt-4 pt-2" style=" text-align:center">
                                    <asp:Button CssClass="btn btnLoginBlack reflejo btn-lg btnLogin" ID="LoginButton" runat="server" CommandName="Login" Text="Iniciar sesión" ValidationGroup="ctl00$Login1"/>
                                    <p class="small fw-bold mt-2 pt-1 mb-0">Versión
                                        <%--<a  href="preRegisterStudent.aspx" class="link-danger">Registrate</a>--%>
                                    </p>
                                    <p class="link-danger">
                                        1.0.0
                                    </p>
                                </div>
                                <div class="text-center text-lg-start mt-4 pt-2" style=" text-align:center">
                                    <p style="text-align:center" class="s mt-2 pt-1 mb-0">¿Quieres regresar al inicio? 
                                        <a href="index.aspx" class="link-danger">Inicio</a>
                                    </p>
                                </div>
                            </LayoutTemplate>
                        </asp:Login>
                    </AnonymousTemplate>                  
                </div>
            </div>
        </div>
        <div class="row" style="width: 100%;position:fixed">
            <div
              class="d-flex flex-column flex-md-row text-center text-md-start justify-content-between py-4 px-4 px-xl-5" style="background-color: #212529;">
                <!-- Copyright -->
                <div class="text-white mb-3 mb-md-0">
                  Copyright © 2023. Todos los derechos reservados.
                </div>
              <!-- Copyright -->

              <!-- Right -->
                <div>
                    <a href="#!" class="text-white me-4">
                      <i class="fab fa-facebook-f"></i>
                    </a>
                    <a href="#!" class="text-white me-4">
                      <i class="fab fa-twitter"></i>
                    </a>
                    <a href="#!" class="text-white me-4">
                      <i class="fab fa-google"></i>
                    </a>
                    <a href="#!" class="text-white">
                      <i class="fab fa-linkedin-in"></i>
                    </a>
                </div>
              <!-- Right -->
            </div>
        </div>
    </section>
        <script src="../vendors/jquery/dist/jquery.min.js"></script>
        <script src="js/personalizados/Login/sessionRecentUser.js"></script>
        <script src="js/personalizados/Login/ajax/deleteSessionRecentAjax.js"></script>    
        <script src="js/personalizados/utils/hideshow.js"></script>
        <script src="bootstrap-5.0.2-dist/js/bootstrap.min.js"></script>
        <script type="text/javascript">                      
        </script>
</form>
</body>
</html>