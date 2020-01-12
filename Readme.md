# How to implement the Context Menu for GridControl rows and cells

GridControl provides the [RowCellMenu](https://docs.devexpress.com/Win10Apps/DevExpress.UI.Xaml.Grid.GridControl.RowCellMenu) property where you can define a custom Context Menu for GridControl rows and cells. You can use either the standard **MenuFlyout** control in this property, or our **ContextToolbarControl** or **ToolbarControl**. To compare these controls, refer to the ***Utility Controls -> Context Menu*** demo available from our [Interactive Demos](https://docs.devexpress.com/WPF/14978/whats-installed/interactive-demos) installed on your machine with our controls.

When you define a menu control in RowCellMenu, this control's DataContext is set to an object of the **GridRowCellContextMenuInfo** class. This class provides information about your GridControl, a target row, cell, column, and etc. You can use this information to process different actions at your view model level. 

In this example, we illustrated how to use the **ContextToolbarControl** in GridControl's **RowCellMenu**. We implemented *DuplicateCommand* and *DeleteCommand* at the view model level. These commands should receive a target data item object to duplicate or delete it respectively. To pass a target data item, you can use the **RowControl** object from **GridRowCellContextMenuInfo**'s **Row** property. RowControl provides its own **Row** property containing the target data item: 

```xaml
xmlns:dxg="using:DevExpress.UI.Xaml.Grid"
xmlns:dxr="using:DevExpress.UI.Xaml.Ribbon"


<dxg:GridControl ...>
    <dxg:GridControl.RowCellMenu>
        <dxr:ContextToolbarControl Orientation="Vertical">
            <dxr:ContextToolbarGroup>
                <dxr:ContextToolbarButton Content="Duplicate"
                                            Command="{Binding Grid.DataContext.DuplicateCommand}"
                                            CommandParameter="{Binding Row.Row}"/>
                <dxr:ContextToolbarButton Content="Delete"
                                            Command="{Binding Grid.DataContext.DeleteCommand}"
                                            CommandParameter="{Binding Row.Row}"/>
            </dxr:ContextToolbarGroup>
        </dxr:ContextToolbarControl>
    </dxg:GridControl.RowCellMenu>
</dxg:GridControl>
```

To bind your menu control's item to a certain command, you need to get access to your view model. As this view model is availble from GridControl's DataContext, use **GridRowCellContextMenuInfo**'s **Grid** property. Refer to the Command property definition in ContextToolbarButtons above.