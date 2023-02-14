<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VinhHyTest.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page Method</title>
    <script src="Scripts/jquery-3.6.3.js" type="text/javascript"></script>
</head> 
<body>
    <form id="form1" runat="server"> 
        <asp:ScriptManager runat="server" ID="sm1" EnablePageMethods="true" />
        
        <script type="text/javascript">
            function onSuccess(data) {
                $('#resultContent').html(data);
            }

            function onFail(msg) {
                alert(msg);
            }

            function add() {
                var name = $('#TxtInput').val();
                PageMethods.Add(name, onSuccess, onFail);
                document.location.reload();
            }

            function remove() {
                PageMethods.Remove(onSuccess, onFail);
                document.location.reload();
            }

            function update() {
                var name = $('#TxtInput').val();
                PageMethods.Update(name, onSuccess, onFail);
                document.location.reload();
            }
        </script>
        <div>
            <div>
                <asp:TextBox ID="TxtInput" runat="server"></asp:TextBox>
                <input style="margin:5px" type="button" value="Add" onclick="add();" />
                <input style="margin:5px" type="button" value="Remove" onclick="remove();" />
                <input style="margin:5px" type="button" value="Update" onclick="update();" />
            </div>
            <br />
            <div id="GV1">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" Width="416px" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" InsertVisible="False" >
                        </asp:BoundField>
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" >
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
            <br />
            <div id="resultContent">
            </div>
        </div>
    </form>
</body>
</html>
