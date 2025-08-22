@ModelType IEnumerable(Of MVC_DatabaseFirst.Shipper)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.CompanyName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Phone)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CompanyName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Phone)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ShipperID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ShipperID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ShipperID })
        </td>
    </tr>
Next

</table>
