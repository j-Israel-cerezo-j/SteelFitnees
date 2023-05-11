<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.Login" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <link rel="shortcut icon" href="images/perzonalizadas/icons/portadaFym-fotor-bg-remover-20230511125220.png" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Entrar - Steel fitness </title>

    <!-- Bootstrap -->
    <link href="bootstrap-5.0.2-dist/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <!-- Font Awesome -->
    
    <link href="css/personalizados/login/style.css" rel="stylesheet" />
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />    
    <link href="css/personalizados/errors.css" rel="stylesheet" />
</head>
<body>
    <div class="demo-container">
        <div class="container">
            <div class="row">
                <div class="col-lg-5 mx-auto">
                    <div class="p-5 bg-white rounded shadow-lg">
                        <h2 class="mb-2 text-center">Steel fitness</h2>
                        <p class="text-center lead">Bienvenido, por favor inicie sesión</p>
                        <form runat="server" id="formLogin"> 
                            <span class="invalid-feedback" role="alert" style="display:inline;">
                                <strong style=" font-family:Verdana">
                                    <asp:Label Font-Names="Verdana" ID="lblErrorMessage" runat="server"></asp:Label>
                                </strong>
                            </span>
                            <AnonymousTemplate>
                                <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate"  CssClass="loginWhite">
                                    <LayoutTemplate>
                                        <div class="row">
                                            <asp:RequiredFieldValidator ID="UserNameRequired" CssClass="errorMessage" runat="server" ControlToValidate="UserName" ErrorMessage="Usuario obligatorio." ToolTip="Usuario obligatorio." ValidationGroup="ctl00$Login1">Usuario obligatorio.</asp:RequiredFieldValidator>
                                        </div>                                        
                                        <label class="font-500">Usuario</label>
                                        <asp:TextBox CssClass="form-control inputsLogin" aria-label="Input group example" placeholder="Nombre de usuario" ID="UserName" runat="server"></asp:TextBox>
                                        <div class="row">
                                            <asp:RequiredFieldValidator ID="PasswordRequired" CssClass="errorMessage" runat="server" ControlToValidate="Password" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="ctl00$Login1">La contraseña es obligatoria.</asp:RequiredFieldValidator>
                                        </div>
                                        <label class="font-500">Contraseña</label>
                                        <asp:TextBox CssClass="form-control inputsLogin" aria-label="Input group example"  placeholder="Contraseña" ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <p class="m-0 py-4"><a href="index.aspx" class="text-muted">¿Quieres regresar al inicio?</a></p>
                                        <asp:Button CssClass="btnLogin btn btn-success btn-lg w-100 shadow-lg" ID="LoginButton" runat="server" CommandName="Login" Text="Iniciar sesión" ValidationGroup="ctl00$Login1"/>
                                    </LayoutTemplate>
                                </asp:Login>
                            </AnonymousTemplate>
                        </form>
                        <div class="text-center pt-4">
                            <p class="m-0">Versión 1.0.0</p>
                        </div>          
                    </div>        
                </div>
            </div>
        </div>
    </div>
</body>
</html>