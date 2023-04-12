<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutUs.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.aboutUs1" MasterPageFile="~/gentelella-master/production/principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>    
    <meta name="description" content=""/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="manifest" href="site.webmanifest"/>
    <link rel="shortcut icon" type="templates/fitnessclub-master/image/x-icon" href="templates/fitnessclub-master/assets/img/favicon.ico"/>
	<!-- CSS here -->
	
	
	<link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <main>       	
		<!--? Start Align Area -->
		<div class="whole-wrap" style="margin-top:80px">
			<div class="container box_1170">				
				<div class="section-top-border text-right">
					<h2 class="mb-30">Misión</h2>
					<div class="row" id="containerMision"></div>
				</div>
                <div class="section-top-border">
					<h2 class="mb-30">Visión</h2>
					<div class="row" id="containerVision"></div>
				</div>
				<div class="section-top-border">
					<h2 class="mb-30">Valores</h2>
					<div class="row">                        
                        <div class="col-md-4">
					        <div class="single-defination">
                                <ul type="a" id="containerValores"></ul>
					        </div>
					    </div>
					</div>
				</div>			
			</div>
		</div>
		<!-- End Align Area -->
	</main>
    <script src="js/personalizados/aboutUsUser/aboutUsRequest.js"></script>
    <script src="js/personalizados/aboutUsUser/build/buildValores.js"></script>
    <script src="js/personalizados/aboutUsUser/build/buildCardsAboutUs.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <!-- JS here -->
    <script src="templates/fitnessclub-master/assets/js/vendor/modernizr-3.5.0.min.js"></script>
    <!-- Jquery, Popper, Bootstrap -->
    <script src="templates/fitnessclub-master/assets/js/vendor/jquery-1.12.4.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/popper.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/bootstrap.min.js"></script>
    <!-- Jquery Mobile Menu -->
    <script src="templates/fitnessclub-master/assets/js/jquery.slicknav.min.js"></script>

    <!-- Jquery Slick , Owl-Carousel Plugins -->
    <script src="templates/fitnessclub-master/assets/js/owl.carousel.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/slick.min.js"></script>
    <!-- One Page, Animated-HeadLin -->
    <script src="templates/fitnessclub-master/assets/js/wow.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/animated.headline.js"></script>
    <script src="templates/fitnessclub-master/assets/js/jquery.magnific-popup.js"></script>

    <!-- Date Picker -->
    <script src="templates/fitnessclub-master/assets/js/gijgo.min.js"></script>
    <!-- Nice-select, sticky -->
    <script src="templates/fitnessclub-master/assets/js/jquery.nice-select.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/jquery.sticky.js"></script>
    
    <!-- counter , waypoint, Hover Direction-->
    <script src="templates/fitnessclub-master/assets/js/jquery.counterup.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/waypoints.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/jquery.countdown.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/hover-direction-snake.min.js"></script>

    <!-- contact js -->
    <script src="templates/fitnessclub-master/assets/js/contact.js"></script>
    <script src="templates/fitnessclub-master/assets/js/jquery.form.js"></script>
    <script src="templates/fitnessclub-master/assets/js/jquery.validate.min.js"></script>
    <script src="templates/fitnessclub-master/assets/js/mail-script.js"></script>
    <script src="templates/fitnessclub-master/assets/js/jquery.ajaxchimp.min.js"></script>
    
    <!-- Jquery Plugins, main Jquery -->	
    <script src="templates/fitnessclub-master/assets/js/plugins.js"></script>
    <script src="templates/fitnessclub-master/assets/js/main.js"></script>

	<script type="text/javascript">

		window.onload = function () {
            aboutUsRequest();
            aboutUsValoresRequest();
		}
    </script>
</asp:Content>
