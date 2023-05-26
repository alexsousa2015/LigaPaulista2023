<%@ Control Language="C#" AutoEventWireup="true" Inherits="LigaPaulista.Site.Admin.adm_menu" Codebehind="menu.ascx.cs" %>
<div id="menu" style="z-index:10;">
	<ul id="navmenu">
	  <li><a href="principal.aspx">Principal</a></li>
	  <li><a href="#">Notícias</a>
	    <ul>
	        <li><a href="noticias.aspx">Listagem</a></li>
	        <li><a href="noticias_add.aspx">Incluir</a></li>
	    </ul>
	  </li>
	  <li><a href="#">Links</a>
	    <ul>
	        <li><a href="links.aspx">Listagem</a></li>
	        <li><a href="links_add.aspx">Incluir Link</a></li>
	    </ul>
	  </li>
	  <li><a href="default.aspx">Sair</a></li>
	</ul>
</div>