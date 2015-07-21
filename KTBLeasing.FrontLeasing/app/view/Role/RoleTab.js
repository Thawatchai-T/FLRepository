Ext.define('TabUserInformation.view.Role.RoleTab', {
    extend: 'Ext.panel.Panel',
    alias: 'widget.roleroletab',

    requires: [
        'TabUserInformation.view.Role.RoleTabViewModel',
        'TabUserInformation.view.Role.RoleTabViewController',
        'Ext.form.Panel',
        'Ext.form.field.Text',
        'Ext.button.Button',
        'Ext.grid.Panel',
        'Ext.toolbar.Fill',
        'Ext.toolbar.Separator',
        'Ext.grid.column.Number',
        'Ext.grid.column.Check',
        'Ext.form.field.Checkbox',
        'Ext.grid.View',
        'Ext.grid.plugin.RowEditing',
        'Ext.selection.CheckboxModel',
        'Ext.toolbar.Paging'
    ],

    controller: 'roleroletab',
    viewModel: {
        type: 'roleroletab'
    },
    layout: 'border',
    //bodyPadding: 5,
    title: 'Role',

    items: [
        {
            xtype: 'form',
            region: 'north',
            reference: 'form',
            itemId: 'myform4',
            bodyPadding: 10,
            //title: 'Search Role form',
            items: [
                {
                    xtype: 'container',
                    layout: {
                        type: 'table',
                        columns: 2
                    },
                    items: [
                        {
                            xtype: 'textfield',
                            width: 333,
                            fieldLabel: 'Search',
                            labelAlign: 'right',
                            labelWidth: 150,
                            name: 'Name'
                        },
                        {
                            xtype: 'button',
                            formBind: true,
                            itemId: 'saveButton',
                            margin: 5,
                            text: 'Search',
                            listeners: {
                                click: 'onSave'
                            }
                        }
                    ]
                }
            ]
        },
        {
            xtype: 'gridpanel',
            region: 'center',
            //bodyPadding: 5,
            title: 'Role Management',
            minHeight: 550,
            height: 730,
            bind: {
                store: '{roles}'
            },
            dockedItems: [
                {
                    xtype: 'toolbar',
                    dock: 'top',
                    items: [
                        {
                            xtype: 'button',
                            text: 'Add',
                            listeners: {
                                click: 'onAddClick'
                            }
                        },
                        {
                            xtype: 'tbfill'
                        },
                        {
                            xtype: 'button',
                            text: 'Delete',
                            listeners: {
                                click: 'onDeleteClick'
                            }
                        },
                        {
                            xtype: 'tbseparator'
                        },
                        {
                            xtype: 'button',
                            text: 'Save',
                            listeners: {
                                click: 'onSaveClick'
                            }
                        }
                    ]
                },
                {
                    xtype: 'pagingtoolbar',
                    dock: 'bottom',
                    ui: 'footer',
                    displayInfo: true,
                    bind: {
                        store: '{roles}'
                    }
                }
            ],
            columns: [
                {
                    xtype: 'gridcolumn',
                    dataIndex: 'RoleName',
                    text: 'Role name',
                    flex: -1,
                    editor: {
                        xtype: 'textfield',
                        width: 100,
                        fieldLabel: ''
                    }
                },
                {
                    xtype: 'checkcolumn',
                    dataIndex: 'Active',
                    text: 'Active',
                    width:100,
                    editor: {
                        xtype: 'checkboxfield'
                    }
                }
            ],
            plugins: [
                {
                    ptype: 'rowediting',
                    listeners: {
                        beforeedit: 'onRowEditingBeforeEdit',
                        canceledit: 'onRowEditingCanceledit',
                        edit: 'onRowEditingEdit',
                        validateedit: 'onRowEditingValidateedit'
                    }
                }
            ],
            selModel: {
                selType: 'checkboxmodel'
            }
        }
    ]

});