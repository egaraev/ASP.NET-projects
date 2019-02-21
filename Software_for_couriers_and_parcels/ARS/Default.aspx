<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadCalendar.NET2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Style="margin-bottom: 0px">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td valign="top" class="style2">
                        <asp:DropDownList ID="year_ddl" runat="server" DataSourceID="Date_sds" 
                            DataValueField="YEAR" DataTextField="YEAR" 
                            ondatabound="year_ddl_DataBound" >
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="year_ddl" ErrorMessage="*" Operator="GreaterThan" 
                            Type="Integer" ValidationGroup="G2" ValueToCompare="0"></asp:CompareValidator>--%>
                        <asp:DropDownList ID="month_ddl" runat="server">
                            <asp:ListItem Value="0">- Выберите месяц -</asp:ListItem>
                            <asp:ListItem Value="1">Январь</asp:ListItem>
                            <asp:ListItem Value="2">Февраль</asp:ListItem>
                            <asp:ListItem Value="3">Март</asp:ListItem>
                            <asp:ListItem Value="4">Апрель</asp:ListItem>
                            <asp:ListItem Value="5">Май</asp:ListItem>
                            <asp:ListItem Value="6">Июнь</asp:ListItem>
                            <asp:ListItem Value="7">Июль</asp:ListItem>
                            <asp:ListItem Value="8">Август</asp:ListItem>
                            <asp:ListItem Value="9">Сентябрь</asp:ListItem>
                            <asp:ListItem Value="10">Октябрь</asp:ListItem>
                            <asp:ListItem Value="11">Ноябрь</asp:ListItem>
                            <asp:ListItem Value="12">Декабрь</asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="month_ddl" ErrorMessage="*" Operator="GreaterThan" 
                            Type="Integer" ValidationGroup="G2" ValueToCompare="0"></asp:CompareValidator>--%>
                        <asp:Button ID="Button1" runat="server" Text="Go!" onclick="Button1_Click" 
                            ValidationGroup="G2" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="Time"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label3" runat="server" Text="Company"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" runat="server" Text="CN"></asp:Label>&nbsp; &nbsp;&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="PCs"></asp:Label>&nbsp;&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="Label7" runat="server" Text="PH"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        &nbsp;&nbsp;
                        <asp:Label ID="Label8" runat="server" Text="Contact person"></asp:Label>&nbsp;&nbsp;
                        <asp:Label ID="Label10" runat="server" Text="Local"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label11" runat="server" Text="Intern"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label12" runat="server" Text="Type"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label13" runat="server" Text="Destination"></asp:Label>&nbsp;&nbsp;
                        <br />
                        <rad:RadDatePicker ID="Date_edt" runat="server" Width="65px" Culture="English (United States)"
                            Skin="Outlook">
                            <DateInput Skin="Outlook" ReadOnly="true">
                            </DateInput>
                            <Calendar Skin="Outlook">
                            </Calendar>
                        </rad:RadDatePicker>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="Hours_ddl" runat="server" Width="57px">
                            <asp:ListItem Value="0">Hour</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="Minutes_ddl" runat="server">
                            <asp:ListItem Value="0">Minute</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                            <asp:ListItem>32</asp:ListItem>
                            <asp:ListItem>33</asp:ListItem>
                            <asp:ListItem>34</asp:ListItem>
                            <asp:ListItem>35</asp:ListItem>
                            <asp:ListItem>36</asp:ListItem>
                            <asp:ListItem>37</asp:ListItem>
                            <asp:ListItem>38</asp:ListItem>
                            <asp:ListItem>39</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>41</asp:ListItem>
                            <asp:ListItem>42</asp:ListItem>
                            <asp:ListItem>43</asp:ListItem>
                            <asp:ListItem>44</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                            <asp:ListItem>46</asp:ListItem>
                            <asp:ListItem>47</asp:ListItem>
                            <asp:ListItem>48</asp:ListItem>
                            <asp:ListItem>49</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>51</asp:ListItem>
                            <asp:ListItem>52</asp:ListItem>
                            <asp:ListItem>53</asp:ListItem>
                            <asp:ListItem>54</asp:ListItem>
                            <asp:ListItem>55</asp:ListItem>
                            <asp:ListItem>56</asp:ListItem>
                            <asp:ListItem>57</asp:ListItem>
                            <asp:ListItem>58</asp:ListItem>
                            <asp:ListItem>59</asp:ListItem>
                            <asp:ListItem>60</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;<asp:TextBox ID="Company_edt" runat="server" Width="101px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;<asp:TextBox ID="Cn_edt" runat="server" Width="23px"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Pcs_edt" runat="server" Width="20px"></asp:TextBox>&nbsp;&nbsp;
                        <asp:TextBox ID="Address_edt" runat="server" Width="140px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;<asp:TextBox ID="Ph_edt" runat="server" Width="96px"></asp:TextBox>&nbsp;&nbsp;
                        <asp:TextBox ID="Contact_edt" runat="server" Width="94px"></asp:TextBox>&nbsp;&nbsp;
                        <asp:DropDownList ID="Local_ddl" runat="server" DataTextField="local">
                            <asp:ListItem Selected="True">local</asp:ListItem>
                            <asp:ListItem>inter</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="Intern_edt" runat="server" Width="59px"></asp:TextBox>&nbsp;&nbsp;
                        <asp:DropDownList ID="Type_ddl" runat="server" DataTextField="Type">
                            <asp:ListItem Selected="True">daily</asp:ListItem>
                            <asp:ListItem>urgent</asp:ListItem>
                            <asp:ListItem>express</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="Destination_edt" runat="server" Width="182px"></asp:TextBox>&nbsp;&nbsp;
                    </td>
                    <td valign="top" class="style3">
                        <br />
                        <asp:Button ID="add_btn" runat="server" Text="Add" OnClick="add_btn_Click" Width="42px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="refresh_btn" runat="server" onclick="refresh_btn_Click" 
                            Text="Refresh" />
                        &nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td valign="top" colspan="2">
                    <br />
                        <asp:Label ID="Error2_lb" runat="server" ForeColor="Red"></asp:Label>
                        <asp:GridView ID="Orders_grid" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" EnableModelValidation="True"
                            Style="margin-top: 0px" Width="1135px" DataKeyNames="ID" ForeColor="#333333" 
                            OnRowCommand="Orders_grid_RowCommand" AutoGenerateEditButton="True" 
                            PageSize="50" GridLines="None" AllowPaging="True">
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Position="TopAndBottom" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Width="720px" />
                            <EmptyDataRowStyle Font-Size="X-Large" ForeColor="Red" />
                            <Columns>
                                <asp:BoundField ApplyFormatInEditMode="True" DataField="DATE" 
                                    DataFormatString="{0:d}" HeaderText="Date" ItemStyle-Width="60px">
                                <ItemStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TIME" HeaderText="Time" />
                                <asp:BoundField DataField="COMPANY" HeaderText="Company" />
                                <asp:BoundField DataField="CN" HeaderText="CN" />
                                <asp:BoundField DataField="PCS" HeaderText="PCs" />
                                <asp:BoundField DataField="ADDRESS" HeaderText="Address" />
                                <asp:BoundField DataField="PH" HeaderText="PH" />
                                <asp:BoundField DataField="CLIENTNAME" HeaderText="Contact person" />
                                <asp:BoundField DataField="LOCAL" HeaderText="Local" />
                                <asp:BoundField DataField="INTERN" HeaderText="Intern" />
                                <asp:BoundField DataField="TYPE" HeaderText="Type" />
                                <asp:BoundField DataField="DESTINATION" HeaderText="Destination" />
                                <asp:ButtonField CommandName="Delete1" Text="Delete" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="Orders_sds" runat="server"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="Date_sds" runat="server"></asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Label ID="Error_lb" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
    </form>
</body>
</html>
