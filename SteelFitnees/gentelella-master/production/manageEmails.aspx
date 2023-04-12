<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageEmails.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.manageEmails" MasterPageFile="~/gentelella-master/production/adminMaster.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar Correos</title>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="x_panel">
		<div class="x_content">
			<h1 id="labelMsjAction">Redactar correo</h1>
			<br>
			<form id="form1" class="row g-3 needs-validation" novalidate>
				<div class="row mt-4">
					<label class="form-label"><b>Asunto:</b></label>
					<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12 form-group" style="margin-top:15px;padding-right: 0px;padding-left:10px;">						
						<input  style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="asunto" id="asunto" placeholder="Asunto del correo"  onkeyup="onkeyupInputEmtyy('asunto')">
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							El asunto del correo es requerido
						</div>
						<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
					</div>
				</div>
				<div class="row mt-4">
					<label class="form-label"><b>Datos del remitente:</b></label>
					<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12 form-group mt-3" style="padding-right: 0px;padding-left:10px;">						
						<input  style="border-radius:6px" type="text" class="form-control has-feedback-left" required="required" name="senderMail" id="senderMail" placeholder="Correo remitente" onkeyup="formantCorrectInput('senderMail','inputEmpty','inputFormantIncorrect','@')">
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback" id="inputEmpty">
							El correo es requerido
						</div>
						<div class="invalid-feedback" id="inputFormantIncorrect" style="display:none">
							Formato incorrecto del correo @
					    </div>
						<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
					</div>					
					<div class="col-lg-6 col-md-6 col-sm-12 col-xsm-12 form-group" style="margin-top:15px;padding-right: 0px;padding-left:10px;">
						<input  style="border-radius:6px" type="password" class="form-control has-feedback-left" required="required" name="senderPassword" id="senderPassword" placeholder="Contraseña"  onkeyup="onkeyupInputEmtyy('senderPassword')">
						<span style="position: absolute;right:10px;top:15px">
                            <svg style="display:block" id="slash" xmlns="http://www.w3.org/2000/svg" width="16" onclick="hideshow('senderPassword','slash','eye')" height="16" fill="currentColor" class="bi bi-eye-fill" viewBox="0 0 16 16">
                              <path d="M10.5 8a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0z"/>
                              <path d="M0 8s3-5.5 8-5.5S16 8 16 8s-3 5.5-8 5.5S0 8 0 8zm8 3.5a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7z"/>
                            </svg>
		            	</span>
                        <span style="position: absolute;right:10px;top:15px">
                            <svg style="display:none" id="eye" xmlns="http://www.w3.org/2000/svg" width="16" onclick="hideshow('senderPassword','slash','eye')" height="16" fill="currentColor" class="bi bi-eye-slash-fill" viewBox="0 0 16 16">
                                <path d="m10.79 12.912-1.614-1.615a3.5 3.5 0 0 1-4.474-4.474l-2.06-2.06C.938 6.278 0 8 0 8s3 5.5 8 5.5a7.029 7.029 0 0 0 2.79-.588zM5.21 3.088A7.028 7.028 0 0 1 8 2.5c5 0 8 5.5 8 5.5s-.939 1.721-2.641 3.238l-2.062-2.062a3.5 3.5 0 0 0-4.474-4.474L5.21 3.089z"/>
                                <path d="M5.525 7.646a2.5 2.5 0 0 0 2.829 2.829l-2.83-2.829zm4.95.708-2.829-2.83a2.5 2.5 0 0 1 2.829 2.829zm3.171 6-12-12 .708-.708 12 12-.708.708z"/>
                            </svg>
		            	</span>
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							La contraseña es requerida
						</div>
						<span class="fa fa-envelope form-control-feedback left" aria-hidden="true"></span>
					</div>
				</div>
				<div class="row mt-3">					
					<div class="col-lg-6 col-md-6 col-sm-12 form-group">
						<div class="mb-3" id="containerFilePhotograph">
							<input style="border-radius:6px" accept="image/jpeg,image/png"  class="form-control" required="required" type="file" id="formFile" onchange="MostraIma(this)" name="image">
							 <div class="valid-feedback">
								¡ Buen trabajo!
							</div>
							<div class="invalid-feedback">
								La imagen es requerida
							</div>
						</div>
					</div>
					<div class="col-lg-6 col-md-6 col-sm-12 form-group">
						<div  class="card reflejo " style="width: 13.9rem;text-align:center">
							<img  id="image" alt="Cargar imagen por favor." src="" height="200" width="220"/>
							<div class="card-body">
								<div id="msjImagenCargadaAutomatica"></div>
							</div>
						</div>
					</div>
				</div>				
				<div class="row mt-4" style="justify-content:center">
					<label class="form-label"><b>Cuerpo del correo:</b></label>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xsm-12 form-group" style="padding-right: 0px;padding-left:10px;">
						<textarea style="border-radius:6px" class="form-control" rows="6" required="required" name="info" id="info" placeholder="Redacte el correo a mandar aqui por favor"  onkeyup="onkeyupInputEmtyy('info')"></textarea>						
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Favor de redactar el correo a mandar
						</div>
					</div>
				</div>
				<div class="row  justify-content-center" style="margin-top:30px" >
					<div class="col-md-6 col-sm-6">
						<div class="form-group row">
							<div class="col-md-6 col-sm-6" id="ctrl-principal">
								<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="send()">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-send-check-fill" viewBox="0 0 16 16">
										<path d="M15.964.686a.5.5 0 0 0-.65-.65L.767 5.855H.766l-.452.18a.5.5 0 0 0-.082.887l.41.26.001.002 4.995 3.178 1.59 2.498C8 14 8 13 8 12.5a4.5 4.5 0 0 1 5.026-4.47L15.964.686Zm-1.833 1.89L6.637 10.07l-.215-.338a.5.5 0 0 0-.154-.154l-.338-.215 7.494-7.494 1.178-.471-.47 1.178Z"/>
										<path d="M16 12.5a3.5 3.5 0 1 1-7 0 3.5 3.5 0 0 1 7 0Zm-1.993-1.679a.5.5 0 0 0-.686.172l-1.17 1.95-.547-.547a.5.5 0 0 0-.708.708l.774.773a.75.75 0 0 0 1.174-.144l1.335-2.226a.5.5 0 0 0-.172-.686Z"/>
									</svg>
									Enviar
								</button>
							</div>
							<div class="col-lg-4 col-md-4 col-sm-9">
								<button style="padding:10px" class="btn btn-secondary reflejo" type="button" onclick="btnReset()"> 
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
									  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2v1z"/>
									  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466z"/>
									</svg>
									Limpiar
								</button>
							</div>
						</div>
					</div>
				</div>
			</form>
			<%-- Tabla Inicio--%>
			<div class="clearfix"></div>
			<div id="containerTableBranches"></div>			
			<%-- Tabla Final--%>			
		</div>
	</div>
    <script src="js/personalizados/SendEmails/ajax/sendAjax.js"></script>
    <script src="js/personalizados/SendEmails/SendEmail.js"></script>
    <script src="js/personalizados/SendEmails/btnReset.js"></script>
	<script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>	
	<script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
	<script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
    <script src="js/personalizados/utils/buildMsjValidOrInvalid.js"></script>    
    <script src="js/personalizados/utils/onkeyupNoSelectInSlc.js"></script>
	<script src="js/personalizados/utils/hideshow.js"></script>

	<script type="text/javascript">
        function MostraIma(input) {
            if (input.files && input.files[0]) {
                var image = new FileReader();
                console.log(image);
                image.onload = function (e) {
                    console.log(e)
                    document.getElementById("image").setAttribute("src", e.target.result);
                    console.log(e.target.result)
                    document.getElementById("msjImagenCargadaAutomatica").innerHTML = ""
                }
                image.readAsDataURL(input.files[0]);

            }
            onkeyupInputEmtyy('formFile')
        }
    </script>
</asp:content> 