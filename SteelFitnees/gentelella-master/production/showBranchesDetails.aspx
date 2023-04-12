<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showBranchesDetails.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.showBranchesDetails" MasterPageFile="~/gentelella-master/production/principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>    
    <meta name="description" content=""/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="manifest" href="site.webmanifest"/>
    <link rel="shortcut icon" type="templates/fitnessclub-master/image/x-icon" href="templates/fitnessclub-master/assets/img/favicon.ico"/>
	<!-- CSS here -->
	<link href="css/personalizados/reflejos.css" rel="stylesheet" />
	<link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<main>
        <!--? About Area Start -->
    <section class="about-area">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-6 col-md-12">
                    <!-- about-img -->
                    <div class="about-img reflejo">
                        <img  src="<%=getListImagesById[0].path %>" alt="">
                    </div>
                </div>
                <div class="col-lg-6 col-md-12">
                    <div class="about-caption">
                        <!-- Section Tittle -->
                        <div class="section-tittle section-tittle3 mb-35">
                            <span>Sucursal</span>
                            <h2><%=getBranche.nombre %></h2>
                        </div>
                        <p class="pera-top"><%=getBranche.descripcion %></p>
                        <p class="mb-65 pera-bottom"><%=getBranche.ubicacion %></p>
                    </div>
                </div>
            </div>
        </div>
       <input type="hidden" value="<%=getIdBranche %>" id="idBranche" />
    </section>    
    <!-- About-2 Area End -->   
    <h1 style="text-align:center">Dias y horarios disponibles de la sucursal<p>Da click en el día</p></h1>
    <%--Horarios inicio--%>
    <section class="date-tabs" style="padding-top: 0px;" >        
        <!-- Heading & Nav Button -->
        <div class="row justify-content-center">
            <div class="col-lg-11">
                <div class="properties__button">
                            <!--Nav Button  -->                                            
                    <nav>      
                        <div  style="justify-content:center" class="nav nav-tabs" id="nav-tab" role="tablist">
                        </div>
                    </nav>
                            <!--End Nav Button  -->
                </div>
            </div>
        </div>
        <!-- Tab content -->
        <div class="row justify-content-center">
            <div class="col-lg-11">
                <!-- Nav Card -->
                <div class="tab-content" id="nav-tabContent" >                                        
                </div>
                <!-- End Nav Card -->
            </div>
        </div>        
    </section>
    <%--Horarios fin--%>

    <div class="container">
             <!--? Gallery Area Start -->
    <div class="gallery-area">
        <div class="container-fluid p-0 fix">
            <div class="row">
                <%foreach (var item in getListImagesById)
                    { %>
                        <div class="col-lg-6 col-md-6 col-sm-6">
                            <div class="box snake mb-30">
                                <div class="gallery-img small-img" style="background-image: url(<%=item.path%>);"></div>                                
                            </div>
                        </div>
                    <% } %>
            </div>
        </div>
    </div>
        <!-- Gallery Area End -->
    </div>
   
        <!--? Want To work -->
    <section class="wantToWork-area w-padding">
        <div class="container">
            <div class="row align-items-end justify-content-between">
                <div class="col-lg-6 col-md-9 col-sm-9">
                    <div class="section-tittle">
                        <span>Productos de la sucursal</span>
                        <h2>Algunos de nuestros productos</h2>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-3 col-md-3">
                    <a href="productsByBranche.aspx" class="btn wantToWork-btn f-right">Mas productos</a>
                </div>
            </div>
        </div>
    </section>
        <!-- Want To work End -->
        <!--? Team Ara Start -->
    <div class="team-area pb-150">
        <div class="container">
            <div class="row" id="containerProducts">
                
            </div>
        </div>
    </div>
        <!-- Team Ara End -->
        <!--? Want To work -->
    <section class="wantToWork-area w-padding section-bg" data-background="templates/fitnessclub-master/assets/img/gallery/section_bg02.png">
        <div class="container">
            <div class="row align-items-center justify-content-between">
                <div class="col-xl-4 col-lg-4 col-md-8 col-sm-10" style="width:100%">
                    <div class="wantToWork-caption">
                        <h2>Visitanos pronto</h2>
                    </div>
                </div> 
                <form id="formComments" class="g-3 needs-validation" novalidate style="width:100%"> 
                    <div style="width:100%" class="col-xl-4 col-lg-4 col-md-8 col-sm-12 col-xsm-12">
                        <label style="color:white" class="form-label">Comentanos tus sugerencias de la sucursal o si fue de tu agarado</label>
                        <textarea class="form-control" rows="6" id="comments" name="comments" required="required" onkeyup="onkeyupInputEmtyy('comments')"></textarea>
                        <div class="valid-feedback">
							¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							El comentario es requerido
						</div>
                    </div>
                </form>
                <div class="col-xl-2 col-lg-2 col-md-3 mt-5">
                    <button class="btn btn-primary" onclick="requestComments()">Enviar</button>
                </div>
            </div>
        </div>
    </section>
        <!-- Want To work End -->
</main>    
    <!-- Scroll Up -->
    <div id="back-top" >
        <a title="Go to Top" href="#"> <i class="fas fa-level-up-alt"></i></a>
    </div>

    <script src="js/personalizados/showBranchesDetails/buildProductById.js"></script>
    <script src="js/personalizados/showBranchesDetails/buildSchedule.js"></script>
    <script src="js/personalizados/showBranchesDetails/requestComments.js"></script>
    <script src="js/personalizados/showBranchesDetails/ajax/branchesAjax.js"></script>
    <script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
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
            var jsonSchedules =<%=getSchedulesByIdBranche%>
            var productsById =<%=getProductsByIdBranche%>
            buildSchedule(jsonSchedules);
            buildProductById(productsById);

        }
    </script>
</asp:Content>
