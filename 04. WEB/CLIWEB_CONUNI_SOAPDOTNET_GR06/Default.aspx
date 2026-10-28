<%@ Page Title="Conversor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ec.edu.monster.vista.DefaultConverter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="converter">
        <section class="converter-header" aria-labelledby="converterTitle">
            <div>
                <h1 id="converterTitle">CONVERSION DE UNIDADES</h1>
            </div>
            <asp:Button ID="btnLogoutTop" runat="server" CssClass="btn-logout-top"
                        Text="Cerrar sesion" OnClick="btnLogout_Click" />
        </section>

        <section class="converter-card">
            <div class="converter-grid">
                <div class="converter-field category-field">
                    <asp:Label runat="server" AssociatedControlID="ddlCategory" CssClass="form-label" Text="Categoria" />
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />
                </div>
                <div class="converter-field">
                    <asp:Label runat="server" AssociatedControlID="ddlFrom" CssClass="form-label" Text="Unidad origen" />
                    <asp:DropDownList ID="ddlFrom" runat="server" CssClass="form-select" />
                </div>
                <div class="converter-field">
                    <asp:Label runat="server" AssociatedControlID="ddlTo" CssClass="form-label" Text="Unidad destino" />
                    <asp:DropDownList ID="ddlTo" runat="server" CssClass="form-select" />
                </div>
                <div class="converter-field value-field">
                    <asp:Label runat="server" AssociatedControlID="txtValue" CssClass="form-label" Text="Valor" />
                    <asp:TextBox ID="txtValue" runat="server" CssClass="form-control" TextMode="Number" />
                </div>
                <div class="converter-actions">
                    <asp:Button ID="btnConvert" runat="server" CssClass="btn-convertir" Text="Convertir" OnClick="btnConvert_Click" />
                    <asp:Button ID="btnClear" runat="server" CssClass="btn-limpiar" Text="Limpiar" OnClick="btnClear_Click" />
                </div>
                <div class="converter-message">
                    <asp:Label ID="lblResult" runat="server" CssClass="converter-result" />
                    <asp:Label ID="lblError" runat="server" CssClass="converter-error" />
                </div>
            </div>
        </section>
    </main>
</asp:Content>
