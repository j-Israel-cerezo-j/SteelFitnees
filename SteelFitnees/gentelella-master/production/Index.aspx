<%@ Page Title="" Language="C#" MasterPageFile="~/gentelella-master/production/principal.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SteelFitnessWEB.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css"/>
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <!-- Masthead-->
    <header class="masthead">
        <div class="container" style="margin-bottom:100px">
            
        </div>
    </header>
            <!-- Carousel-->
    <div id="carouselExampleDark" class="carousel carousel-dark slide" data-bs-ride="carousel">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleDark" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active" data-bs-interval="4000">
                <img src="sources/slide2.jpg" class="d-block w-100" alt="..." width="100">
                <div class="carousel-caption d-none d-md-block">
                    <h2 style="color:white" class="section-heading text-uppercase">INSTALACIONES DE PRIMER NIVEL</h2>
                    <p style="color:white">Some representative placeholder content for the first slide.</p>
                </div>
            </div>
            <div class="carousel-item" data-bs-interval="4000">
                <img src="sources/runn.jpg" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h2 style="color:white" class="section-heading text-uppercase">ENTRENADORES CERTIFICADOS</h2>
                    <p style="color:white">Some representative placeholder content for the second slide.</p>
                </div>
            </div>
            <div class="carousel-item" data-bs-interval="4000">
                <img src="sources/slide1.jpg" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h2 style="color:white" class="section-heading text-uppercase">EXCELENTE UBICACION</h2>
                    <p style="color:white">Some representative placeholder content for the third slide.</p>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span style="color:white" class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleDark" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span style="color:white" class="visually-hidden">Next</span>
        </button>
    </div>

    <!-- Carousel wrapper -->
    <div id="carouselMultiItemExample" class="carousel slide carousel-dark text-center" data-mdb-ride="carousel"> 
      <!-- Inner -->
        <div class="text-center mt-5"  >
            <h2  class="section-heading text-uppercase">Sucursales</h2>
            <h3 class="section-subheading text-muted">Visita nuestras sucursales</h3>
        </div>
        <div class="container">
            <div class="row mt-5" style="justify-content:center" id="team"></div>   
        </div>        
      <!-- Inner -->
    </div>
    <!-- Carousel wrapper -->    
            <!-- Contact-->
    <section class="page-section mt-5" id="contact">
        <div class="container">
            <div class="text-center">
                <h2 class="section-heading text-uppercase">Contactanos</h2>
            </div>
            <form id="contactForm" class="row g-3 needs-validation mt-4" novalidate>
                <div class="row align-items-stretch mb-5" style="justify-content:center;">
                    <div class="col-md-6">
                        <div class="form-group">
                            <!-- Name input-->
                            <input class="form-control" name="nombre" id="nombre" type="text" placeholder="Tu nombre" data-sb-validations="required" />
                            <div class="invalid-feedback" data-sb-feedback="name:required">El nombre es requerido.</div>
                        </div>
                        <div class="form-group">
                            <!-- Email address input-->
                            <input class="form-control" name="email" id="email" type="email" placeholder="Tu correo electronico" data-sb-validations="required,email" />
                            <div class="invalid-feedback" data-sb-feedback="email:required">El correo es requerido</div>
                            <div class="invalid-feedback" data-sb-feedback="email:email">Correo no valido.</div>
                        </div>
                    </div>
                </div>                                    
                <!-- Submit Button-->               
                <div class="text-center"><button style="padding: 30px;font-size: 25px;" class="btn" type="button" id="submitButton" onclick="addContact()">ENVIAR</button></div>
            </form>
            
        </div>
    </section>
    <script src="js/personalizados/contactForm/add.js"></script>
    <script src="js/personalizados/contactForm/ajax/enviiat.js"></script>
    <script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
    <script src="js/personalizados/Index/requestBranches.js"></script>
    <script src="js/personalizados/Index/build/buildCardsBranches.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.15.5/dist/sweetalert2.all.min.js" integrity="sha256-92U7H+uBjYAJfmb+iNPi7DPoj795ZCTY4ZYmplsn/fQ=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        window.onload = function () {
            requestBranches();
        }
</script>
</asp:Content>
