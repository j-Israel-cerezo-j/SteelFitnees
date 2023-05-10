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
    <link href="css/personalizados/cards.css" rel="stylesheet" />
    
    <link href="frontend/css/styleIndex.css" rel="stylesheet" />
    <link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css">    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<main style="
            background-image: url(<%=getListImagesById[0].path%>);
            background-repeat:no-repeat;
            background-attachment:fixed;
            background-size:cover;
            color:#FFFFFF">
    <div class="row"></div>
        <!--? About Area Start -->
    <section class="about-area" style="padding-bottom:50px">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-6 col-md-12">
                    <!-- about-img -->
                    <div class="about-img reflejo">
                        <img  src="<%=getListImagesById[0].path %>" alt="">
                    </div>
                </div>
                <div class="col-lg-6 col-md-12" style="background-color:white">
                    <div class="about-caption">
                        <!-- Section Tittle -->
                        <div class="section-tittle section-tittle3 mb-35">
                            <span>Sucursal</span>
                            <h2><%=getBranche.nombre %></h2>
                        </div>
                        <p class="pera-top"><%=getBranche.descripcion %></p>
                        <span>
                            <svg xmlns="http://www.w3.org/2000/svg" width="41" height="39" viewBox="0 0 41 39" fill="none">
                                <g clip-path="url(#clip0_232_8451)">
                                    <path fill-rule="evenodd" clip-rule="evenodd" d="M19.8869 1.41455C13.6337 1.41455 8.56445 6.48376 8.56445 12.737C8.56445 14.3625 9.10403 16.3327 9.86945 18.2917C10.6458 20.2786 11.7004 22.3683 12.8294 24.2699C13.9562 26.168 15.1791 27.9156 16.3048 29.2062C16.8652 29.8487 17.4293 30.4101 17.9699 30.8217C18.4591 31.1942 19.1362 31.6076 19.8869 31.6076C20.6375 31.6076 21.3146 31.1942 21.8038 30.8217C22.3444 30.4101 22.9085 29.8487 23.4689 29.2062C24.5947 27.9156 25.8175 26.168 26.9443 24.2699C28.0733 22.3683 29.1279 20.2786 29.9043 18.2917C30.6697 16.3327 31.2093 14.3625 31.2093 12.737C31.2093 6.48376 26.14 1.41455 19.8869 1.41455ZM11.0805 12.737C11.0805 7.87336 15.0233 3.93064 19.8869 3.93064C24.7504 3.93064 28.6932 7.87336 28.6932 12.737C28.6932 13.8906 28.2892 15.5115 27.5607 17.376C26.8431 19.2126 25.8535 21.1786 24.7808 22.9854C23.7061 24.7957 22.5701 26.409 21.5728 27.5523C21.0718 28.1267 20.6334 28.5505 20.2796 28.8198C20.0783 28.9731 19.95 29.0411 19.8869 29.0708C19.8237 29.0411 19.6954 28.9731 19.4941 28.8198C19.1403 28.5505 18.7019 28.1267 18.2009 27.5523C17.2036 26.409 16.0676 24.7957 14.9929 22.9854C13.9203 21.1786 12.9306 19.2126 12.213 17.376C11.4845 15.5115 11.0805 13.8906 11.0805 12.737Z" fill="#666666"></path>
                                    <path fill-rule="evenodd" clip-rule="evenodd" d="M19.9931 7.70483C17.2139 7.70483 14.9609 9.95782 14.9609 12.737C14.9609 15.5162 17.2139 17.7692 19.9931 17.7692C22.7723 17.7692 25.0253 15.5162 25.0253 12.737C25.0253 9.95782 22.7723 7.70483 19.9931 7.70483ZM17.477 12.737C17.477 11.3474 18.6035 10.2209 19.9931 10.2209C21.3827 10.2209 22.5092 11.3474 22.5092 12.737C22.5092 14.1266 21.3827 15.2531 19.9931 15.2531C18.6035 15.2531 17.477 14.1266 17.477 12.737Z" fill="red"></path>
                                    <path fill-rule="evenodd" clip-rule="evenodd" d="M13.7068 27.7512C9.11117 28.6539 5.93066 30.6016 5.93066 32.8589C5.93066 35.9757 11.9948 38.5024 19.4752 38.5024C26.9557 38.5024 33.0198 35.9757 33.0198 32.8589C33.0198 30.7136 30.1472 28.848 25.9173 27.8933C25.4886 28.5201 24.9945 29.2064 24.4182 29.8931C25.8657 30.1522 27.1421 30.5177 28.1844 30.952C29.2467 31.3947 29.959 31.8642 30.3712 32.2703C30.5708 32.467 30.6709 32.6201 30.7183 32.7166C30.7618 32.805 30.7623 32.8469 30.7623 32.8589C30.7623 32.8708 30.7618 32.9127 30.7183 33.0011C30.6709 33.0977 30.5708 33.2507 30.3712 33.4474C29.959 33.8535 29.2467 34.3231 28.1844 34.7657C26.0697 35.6468 22.9919 36.245 19.4752 36.245C15.9585 36.245 12.8807 35.6468 10.766 34.7657C9.70374 34.3231 8.99148 33.8535 8.57929 33.4474C8.37962 33.2507 8.27951 33.0977 8.2321 33.0011C8.18868 32.9127 8.18809 32.8708 8.18809 32.8589C8.18809 32.8469 8.18868 32.805 8.2321 32.7166C8.27951 32.6201 8.37962 32.467 8.57929 32.2703C8.99148 31.8642 9.70374 31.3947 10.766 30.952C11.9798 30.4463 13.5108 30.0338 15.2601 29.7741C14.6487 29.0424 14.1006 28.3042 13.7068 27.7512Z" fill="red"></path>
                                </g>
                                <defs>
                                    <clipPath id="clip0_232_8451">
                                        <rect width="40.2574" height="38" fill="white" transform="translate(0.287109 0.662109)"></rect>
                                    </clipPath>
                                </defs>
                            </svg>
                        </span>
                        <p class="mb-65 pera-bottom"><%=getBranche.ubicacion %></p>
                    </div>
                </div>
            </div>
        </div>
       <input type="hidden" value="<%=getIdBranche %>" id="idBranche" />
    </section>    
    <!-- About-2 Area End -->
    <%--Horarios inicio--%>
    <div class="row" style="background-color: white; margin-left: 57px;margin-right:57px;padding:40px">
        <svg onclick="buildScheduleToday()" xmlns="http://www.w3.org/2000/svg" width="35" height="34" viewBox="0 0 35 34" fill="none">
            <g clip-path="url(#clip0_232_8433)">
                <path d="M16.6525 9.00254C16.6525 8.24471 17.2525 7.63037 17.9927 7.63037C18.7329 7.63037 19.333 8.24471 19.333 9.00254V18.6078C19.333 19.3656 18.7329 19.9799 17.9927 19.9799H11.2914C10.5512 19.9799 9.95117 19.3656 9.95117 18.6078C9.95117 17.8499 10.5512 17.2356 11.2914 17.2356H16.6525V9.00254Z" fill="red"></path>
                <path d="M17.2872 32.4519C9.16646 32.4519 2.53031 25.7031 2.53031 17.312C2.53031 8.92091 9.16646 2.17216 17.2872 2.17216C25.408 2.17216 32.0442 8.92091 32.0442 17.312C32.0442 25.7031 25.408 32.4519 17.2872 32.4519Z" stroke="#666666" stroke-width="2.65243"></path>
            </g>
            <defs>
                <clipPath id="clip0_232_8433">
                    <rect width="33.1553" height="33.1553" fill="white" transform="translate(0.911133 0.600098)"></rect>
                </clipPath>
            </defs>
        </svg>
        <h1 style="text-align:center">Dias y horarios disponibles de la sucursal<p>Da click en el día</p></h1>
    </div>
    <section class="date-tabs" style="padding-top: 0px;padding-bottom:80px" >       
        <!-- Heading & Nav Button -->
        <div class="row justify-content-center">
            <div class="col-lg-11">
                <div class="properties__button">
                            <!--Nav Button  -->                                            
                    <nav>      
                        <div  style="justify-content:center;width:100%" class="nav nav-tabs row" id="nav-tab" role="tablist"></div>
                    </nav>
                            <!--End Nav Button  -->
                </div>
            </div>
        </div>
        <!-- Tab content -->
        <div class="row justify-content-center" style="background-color:black;">
            <div class="col-lg-11">
                <!-- Nav Card -->
                <div class="tab-content" id="nav-tabContent" style="padding-bottom:10px" >                                        
                </div>
                <!-- End Nav Card -->
            </div>
        </div>        
    </section>
    <%--Horarios fin--%>

             <!--? Gallery Area Start -->
        <div class="gallery-area">
            <div class="container-fluid p-0 fix">
                <div class="row" style="justify-content:center">
                    <div class="col-lg-6">                    
                        <div id="carouselExampleDark" class="carousel carousel-dark" data-bs-ride="carousel">
                            <div class="carousel-indicators">
                                 <%if (getListImagesById != null && getListImagesById.Count > 0)
                                { %>
                                    <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                                    <%for (int i = 1; i < getListImagesById.Count; i++)
                                        {%>
                                            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="<%=i %>" aria-label="Slide <%=i+1 %>"></button>
                                        <%} %>
                                <%} %>
                            </div>
                            <div class="carousel-inner">
                            <%if (getListImagesById != null && getListImagesById.Count > 0)
                            { %>
                                <div class="carousel-item active" data-bs-interval="3000">
                                    <img src="<%=getListImagesById[0].path%>" class="d-block reflejo" alt="..." width="650" height="450" >
                                </div>
                                 <%for (int i = 1; i < getListImagesById.Count; i++)
                                { %>
                                    <div class="carousel-item" data-bs-interval="3000">
                                        <img src="<%=getListImagesById[i].path %>" class="d-block reflejo" alt="..." width="650" height="450">
                                    </div>                          
                                <%}%>      
                            <%} %>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Gallery Area End -->
   
        <!--? Want To work -->
    <section class="wantToWork-area w-padding mt-4" style="background-color:white">
        <div class="container">
            <div class="row align-items-end justify-content-between">
                <div class="col-lg-6 col-md-9 col-sm-9">
                    <div class="section-tittle">
                        <span>Productos de la sucursal</span>
                        <h2>Algunos de nuestros productos</h2>
                    </div>
                </div>
                <div class="col-xl-3 col-lg-3 col-md-3">
                    <a style="border-radius:30px" href="productsByBranche.aspx" class="btn wantToWork-btn f-right">Mas productos</a>
                </div>
            </div>
        </div>
    </section>
        <!-- Want To work End -->
        <!--? Team Ara Start -->
    <div class="team-area pb-150" style="background-color:white">
        <div class="container">
            <div class="row" id="containerProducts">
                
            </div>
        </div>
    </div>
        <!-- Team Ara End -->
    <div class="container" style="margin:15px">
        <div class="col-xl-2 col-lg-2 col-md-3">
            <a style="font-size:25px;border-radius:30px" id="return" class="btn">Regresar</a>
        </div>
    </div>    
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
                        <label style="color:white" class="form-label">Comentanos tus sugerencias de la sucursal o si fue de tu agrado</label>
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
                    <button class="btn" style="border-radius:30px" onclick="requestComments()">Enviar</button>
                </div>
            </div>
        </div>
    </section>
        <!-- Want To work End -->
</main>    
    <!-- Scroll Up -->
    <div id="back-top" >
        <a title="Go to Top"> <i class="fas fa-level-up-alt"></i></a>
    </div>
    <script src="js/personalizados/showBranchesDetails/addUrlReturn.js"></script>
    <script src="js/personalizados/showBranchesDetails/buildProductById.js"></script>
    <script src="js/personalizados/showBranchesDetails/buildSchedule.js"></script>
    <script src="js/personalizados/showBranchesDetails/requestComments.js"></script>
    <script src="js/personalizados/showBranchesDetails/ajax/branchesAjax.js"></script>

    <script src="js/personalizados/utils/zoomImg.js"></script>
    <script src="js/personalizados/utils/formant12HourTime.js"></script>
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
            addUrlReturn();

        }
    </script>
</asp:Content>
