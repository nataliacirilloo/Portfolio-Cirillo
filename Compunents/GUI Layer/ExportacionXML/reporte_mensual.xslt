<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" indent="yes" encoding="UTF-8"/>

	<xsl:template match="/">
		<Productos>
			<xsl:for-each select="ReporteMensual/Producto">
				<Producto>
					<ID>
						<xsl:value-of select="Id_Producto"/>
					</ID>
					<Nombre>
						<xsl:value-of select="NombreProducto"/>
					</Nombre>
					<Pedidos>
						<xsl:value-of select="Id_Pedido"/>
					</Pedidos>
					<Unidades>
						<xsl:value-of select="TotalItems"/>
					</Unidades>
					<Recaudacion>
						<xsl:value-of select="SubtotalItem"/>
					</Recaudacion>
					<PorcentajeMes>
						<xsl:value-of select="TotalCalculado"/>
					</PorcentajeMes>
				</Producto>
			</xsl:for-each>
		</Productos>
	</xsl:template>
</xsl:stylesheet>
