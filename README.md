# Mastering-Data-Presentation-A-Deep-Dive-into-the-Syncfusion-MAUI-DataGrid

This guide provides a deep dive into mastering data presentation using the Syncfusion MAUI DataGrid (`SfDataGrid`). It covers essential features such as custom row and column configuration, filtering, sorting, grouping, and adaptive layouts, referencing the official [Syncfusion MAUI DataGrid User Guide](https://help.syncfusion.com/maui/datagrid/getting-started). The code samples are taken directly from the implementation in this repository.

## Overview
The Syncfusion MAUI DataGrid is a powerful control for displaying and manipulating tabular data in .NET MAUI applications. It supports advanced features like sorting, grouping, filtering, editing, and custom styling, making it ideal for business and analytics apps.

## Key Features Demonstrated
- **Manual Column Definition**: Full control over column order, headers, and bindings.
- **Row and Cell Selection**: Single row selection, cell navigation, and sort indicators.
- **Filtering**: Custom filter logic to display only relevant records.
- **Grouping and Summaries**: Grouping by columns and displaying summary rows (see commented code for advanced usage).
- **Platform-Specific Visibility**: Columns shown/hidden based on platform.
- **Styling**: Custom header cell styles for improved readability.

## XAML Setup
The following XAML snippet configures the `SfDataGrid` with manual columns, selection, sorting, grouping, and platform-specific visibility:
```xml
<ContentPage.BindingContext>
    <local:TemplateViewModel/>
</ContentPage.BindingContext>

<syncfusion:SfDataGrid AutoGenerateColumnsMode="None"
					   SelectionUnit="Row"
					   NavigationMode="Cell"
					   AllowEditing="True"
					   SelectionMode="Single"
					   SortingMode="Multiple"
					   x:Name="dataGrid"
					   ShowSortNumbers="True"
					   Loaded="SfDataGrid_Loaded"
					   GridLinesVisibility="Both"
					   GroupingMode="Multiple"
					   Margin="10"
					   HeaderGridLinesVisibility="Both"
					   ItemsSource="{Binding DealerInformation}"
					   ColumnWidthMode="Fill">
	<syncfusion:SfDataGrid.Columns>
		<syncfusion:DataGridNumericColumn HeaderText="Order ID" Format="D" MappingName="OrderID" />
		<syncfusion:DataGridTextColumn HeaderText="Customer ID" MappingName="CustomerID" />
		<syncfusion:DataGridTextColumn HeaderText="Name" MappingName="DealerName" />
		<syncfusion:DataGridTextColumn HeaderText="Quantity" MappingName="Quantity">
			<syncfusion:DataGridTextColumn.Visible>
				<OnPlatform x:TypeArguments="x:Boolean">
					<On Platform="iOS,Android" Value="False" />
					<On Platform="WinUI,MacCatalyst" Value="True" />
				</OnPlatform>
			</syncfusion:DataGridTextColumn.Visible>
		</syncfusion:DataGridTextColumn>
		<syncfusion:DataGridTextColumn HeaderText="Freight" MappingName="Freight">
			<syncfusion:DataGridTextColumn.Visible>
				<OnPlatform x:TypeArguments="x:Boolean">
					<On Platform="iOS,Android" Value="False" />
					<On Platform="WinUI,MacCatalyst" Value="True" />
				</OnPlatform>
			</syncfusion:DataGridTextColumn.Visible>
		</syncfusion:DataGridTextColumn>
	</syncfusion:SfDataGrid.Columns>
</syncfusion:SfDataGrid>
```

## Filtering Logic
The following C# code demonstrates how to filter records so only those with `DealerName == "Jefferson"` are displayed:
```csharp
private void SfDataGrid_Loaded(object sender, EventArgs e)
{
	dataGrid.View.Filter = FilterRecords;
}
public bool FilterRecords(object record)
{
	TemplateModel? templateModel = record as TemplateModel;
	if (templateModel != null && templateModel.DealerName == "Jefferson")
	{
		return true;
	}
	return false;
}
```

## Styling and Customization
Header cells are styled for emphasis using bold font attributes:
```xml
<ContentPage.Resources>
    <Style TargetType="syncfusion:DataGridHeaderCell">
        <Setter Property="FontAttributes" Value="Bold"/>
    </Style>
</ContentPage.Resources>
```

##### Conclusion

I hope you enjoyed learning how to master data presentation in .NET MAUI DataGrid (SfDataGrid).
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!