<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SteelFitnees.Index" MasterPageFile="~/masterUser.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
    <link href="css/personalizados/sliderPromotions.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:content id="Content2" ContentPlaceHolderID="bodyContent" runat="server">	
    <!-- Hero Section Begin -->
    <section class="hero-section">
        <div class="hs-slider owl-carousel">
            <div class="hs-item set-bg" data-setbg="img/hero/hero-1.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 offset-lg-6">
                            <div class="hi-text">
                                <span>Shape your body</span>
                                <h1>Be <strong>strong</strong> traning hard</h1>
                                <a href="#" class="primary-btn">Get info</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="hs-item set-bg" data-setbg="img/hero/hero-2.jpg">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 offset-lg-6">
                            <div class="hi-text">
                                <span>Shape your body</span>
                                <h1>Be <strong>strong</strong> traning hard</h1>
                                <a href="#" class="primary-btn">Get info</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Hero Section End -->
     <!-- ChoseUs Section Begin -->
    <section class="choseus-section spad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="section-title">
                        <span>Why chose us?</span>
                        <h2>PUSH YOUR LIMITS FORWARD</h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3 col-sm-6">
                    <div class="cs-item">
                        <span class="flaticon-034-stationary-bike"></span>
                        <h4>Modern equipment</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
                            dolore facilisis.</p>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="cs-item">
                        <span class="flaticon-033-juice"></span>
                        <h4>Healthy nutrition plan</h4>
                        <p>Quis ipsum suspendisse ultrices gravida. Risus commodo viverra maecenas accumsan lacus vel
                            facilisis.</p>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="cs-item">
                        <span class="flaticon-002-dumbell"></span>
                        <h4>Proffesponal training plan</h4>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
                            dolore facilisis.</p>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-6">
                    <div class="cs-item">
                        <span class="flaticon-014-heart-beat"></span>
                        <h4>Unique to your needs</h4>
                        <p>Quis ipsum suspendisse ultrices gravida. Risus commodo viverra maecenas accumsan lacus vel
                            facilisis.</p>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- ChoseUs Section End -->
    <!-- Banner Section Begin -->
    <section class="banner-section set-bg" data-setbg="img/banner-bg.jpg">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <div class="bs-text">
                        <h2>Registrate al NEWSLETTER</h2>
                        <div class="bt-tips">Recibe nuestras promociones en el momento..</div>
                          <!-- Contact Section Begin -->
                            <section>
                                <div class="container">
                                    <div class="row" style="justify-content:center">
                                        <div class="col-lg-6">
                                            <div class="leave-comment">
                                                <form id="contactForm" class="g-3 needs-validation mt-4" novalidate>
                                                    <input required="required" name="nombre" id="nombre" type="text" placeholder="Tu nombre"  onkeyup="onkeyupInputEmtyy('nombre')"/>
                                                    <div class="valid-feedback">
							                        	¡ Buen trabajo!
						                            </div>
						                            <div class="invalid-feedback">
							                            Tu nombre es requerido
						                            </div>
                                                    <input required="required" name="email" id="email" type="email" placeholder="Tu correo electronico"  onkeyup="formantCorrectInput('email','inputEmpty','inputFormantIncorrect','@')"/>
                                                    <div class="valid-feedback">
							                        	¡ Buen trabajo!
						                            </div>
						                            <div class="invalid-feedback" id="inputEmpty">
						                            	El correo es requerido
						                            </div>
                                                    <div class="invalid-feedback" id="inputFormantIncorrect" style="display:none">
							                            Formato incorrecto del correo @
					                                </div>
                                                    <button type="button" id="submitButton" onclick="addContact()">Enviar</button>
                                                </form>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </section>
                        <!-- Contact Section End -->                        
                    </div>
                </div>
            </div>
        </div>
    </section>
     <!-- Pricing Section Begin -->
    <section class="pricing-section" style="padding-top:100px">
        <div class="row">
                <div class="col-lg-12">
                    <div class="section-title">
                        <span>Sucursales</span>
                        <h2>Conoce nuestras ubicaciones</h2>
                    </div>
                </div>
            </div>
    </section>
    <!-- Pricing Section End -->
    <!-- Blog Section Begin -->
    <section class="blog-section" style="padding-bottom:100px">
        <div class="container">
            <div class="row" id="team"></div>
        </div>
    </section>
    <!-- Blog Section End -->

     <!-- Team Section Begin -->
    <section class="team-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="team-title">
                        <div class="section-title">
                            <span>Promociones</span>
                            <h2>No te las pierdas</h2>
                        </div>
                        <a href="#" class="primary-btn btn-normal appoinment-btn">appointment</a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="ts-slider owl-carousel" id="containerPromotions">
                </div>
            </div>
        </div>
    </section>
    <!-- Team Section End -->
    <script src="js/personalizados/Index/requestPromotions.js"></script>
    <script src="js/personalizados/contactForm/add.js"></script>
    <script src="js/personalizados/contactForm/ajax/enviiat.js"></script>

    <script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <script src="js/personalizados/utils/returnOpeningStatus.js"></script>
    <script src="js/personalizados/utils/formant12HourTime.js"></script>

    
    <script src="js/personalizados/Index/addU.js"></script>
    <script src="js/personalizados/Index/requestBranches.js"></script>
    <script src="js/personalizados/Index/build/buildCardsBranches.js"></script>
        
    <script src="js/personalizados/allBranches/msjOpeningBrancheCards.js"></script>
    <script src="js/personalizados/allBranches/requestCommentsByBranche.js"></script>

    <script type="text/javascript">
        window.onload = function () {
            requestPromotions();
            requestBranches();
        }
    </script>
</asp:Content>

