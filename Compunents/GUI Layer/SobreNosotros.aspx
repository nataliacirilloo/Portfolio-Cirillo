<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SobreNosotros.aspx.cs" Inherits="GUI_Layer.SobreNosotros" %>
<%@ Register Src="~/Controls/TopBar.ascx" TagPrefix="uc" TagName="TopBar" %>

<!DOCTYPE html>
<%-- El atributo lang="es" es importante para la accesibilidad y el SEO --%>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <%-- Se utiliza la etiqueta meta moderna y recomendada para el charset --%>
    <meta charset="utf-8" />
    <%-- El viewport asegura que la página se vea bien en dispositivos móviles --%>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <%-- Una descripción es crucial para que Google muestre tu página en los resultados de búsqueda --%>
    <meta name="description" content="Descubre la historia y misión de Compunents. Conoce a nuestro equipo y dónde encontrarnos en Buenos Aires." />
    
    <title>Sobre Nosotros - Compunents</title>
    
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/TopBar.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        /* El .container de Bootstrap ya centra y añade padding, 
           pero puedes sobreescribirlo si necesitas algo específico.
           Este selector asegura que los estilos se apliquen dentro del <main> */
        main.container {
            padding-top: 20px;
            padding-bottom: 20px;
            max-width: 1000px;
            margin-left: auto;
            margin-right: auto;
        }

        /* Espaciado entre secciones para mejor legibilidad */
        .about-us-intro,
        .location-map {
            margin-bottom: 40px;
        }

        h1, h2 {
            color: #333;
        }

        .map-container {
            margin-top: 20px;
            width: 100%;
            /* Usar aspect-ratio es más moderno y responsivo que una altura fija */
            aspect-ratio: 16 / 9; /* Proporción panorámica, ideal para mapas */
            height: 400px; /* Se mantiene por compatibilidad con navegadores antiguos */
        }

        .map-container iframe {
            border: 0;
            width: 100%;
            height: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc:TopBar ID="TopBarControl" runat="server" />
        
        <%-- El tag <main> es semánticamente correcto para el contenido principal de la página --%>
        <main class="container">
            
            <%-- Usar <section> ayuda a estructurar el contenido temáticamente para SEO y accesibilidad --%>
            <section class="about-us-intro">
                <h1>Sobre Nosotros</h1>
                <%-- Se reemplaza "Lorem ipsum" con contenido real y descriptivo --%>
                <p>
                    Bienvenido a Compunents, tu aliado de confianza en soluciones tecnológicas. Desde nuestra fundación en [Año de Fundación], nos hemos dedicado a ofrecer componentes de alta calidad y un servicio al cliente excepcional. Nuestra misión es potenciar tus proyectos con la mejor tecnología disponible en el mercado.
                </p>
                <p>
                    Creemos en la innovación, la calidad y la satisfacción del cliente. Nuestro equipo está compuesto por apasionados de la tecnología, siempre listos para asesorarte y ayudarte a encontrar la solución perfecta para tus necesidades.
                </p>
            </section>
            
            <section class="location-map">
                <h2>Nuestra Ubicación</h2>
                <div class="map-container">
                    <iframe 
                        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3282.7206119871966!2d-58.45259282357829!3d-34.600665572954314!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95bccb1a733cb37d%3A0x7e712bd23c7ce4ba!2sCompra%20Gamer%2C%20Centro%20de%20Servicio%20Postventa.!5e0!3m2!1ses!2sar!4v1717436441453!5m2!1ses!2sar" 
                        allowfullscreen="" 
                        loading="lazy" 
                        referrerpolicy="no-referrer-when-downgrade"
                        title="Mapa de la ubicación de Compunents">
                    </iframe>
                </div>
            </section>

        </main>
    </form>
</body>
</html>