﻿/*
* File: app/view/Popup/AddressPopup.js
*
* This file was generated by Sencha Architect version 3.1.0.
* http://www.sencha.com/products/architect/
*
* This file requires use of the Ext JS 5.0.x library, under independent license.
* License of Sencha Architect does not include license for Ext JS 5.0.x. For more
* details see http://www.sencha.com/license or contact license@sencha.com.
*
* This file will be auto-generated each and everytime you save your project.
*
* Do NOT hand edit this file.
*/

Ext.define('TabUserInformation.view.Common.AddressPopup', {
    extend: 'Ext.window.Window',
    alias: 'widget.popupaddresspopup',

    requires: [
        'TabUserInformation.view.Common.AddressPopupViewModel',
        'TabUserInformation.view.Common.AddressPopupViewController',
        'Ext.form.Panel',
        'Ext.form.field.ComboBox',
        'Ext.form.field.TextArea',
        'Ext.XTemplate',
        'Ext.form.field.Checkbox',
        'Ext.toolbar.Toolbar',
        'Ext.button.Button'
    ],

    controller: 'popupaddresspopup',
    viewModel: {
        type: 'popupaddresspopup'
    },
    autoShow: true,
    width: 750,
    title: 'Address',
    modal: true,

    items: [
        {
            xtype: 'form',
            bodyPadding: 10,
            layout: {
                type: 'table',
                columns: 2
            },
            items: [
                {
                    xtype: 'hiddenfield',
                    name: 'Id'
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Customer Code',
                    name: 'CustomerId',
                    readOnly: true,
                    allowBlank: false
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    width: '90%',
                    fieldLabel: 'Customer Name',
                    name: 'CustomerThaiName',
                    readOnly: true,
                    allowBlank: false
                },
                {
                    xtype: 'combobox',
                    colspan: 2,
                    fieldLabel: 'ประเภทที่อยู่',
                    labelAlign: 'right',
                    name: 'AddressType',
                    store: 'CommonData.addressTypes',
                    valueField: 'Id',
                    displayField: 'Name',
                    autoLoadOnValue: true,
                    allowBlank: false
                },
                {
                    xtype: 'textareafield',
                    colspan: 2,
                    width: '90%',
                    fieldLabel: 'ที่อยู่',
                    labelAlign: 'right',
                    name: 'AddressTh',
                    allowBlank: false
                },
                {
                    xtype: 'textareafield',
                    colspan: 2,
                    width: '90%',
                    fieldLabel: 'Address',
                    labelAlign: 'right',
                    name: 'AddressEng',
                    allowBlank: false
                },
                {
                    xtype: 'combobox',
                    reference: 'province',
                    colspan: 2,
                    width: '90%',
                    fieldLabel: 'Sub District',
                    labelAlign: 'right',
                    name: 'SubdistrictId',
                    allowBlank: false,
                    //autoLoadOnValue: true,
                    tpl: [
                        '<ul class="x-list-plain">',
                            '<tpl for=".">',
                                '<li class="x-boundlist-item">',
                                    '{ProvinceName} {DistrictName} {SubdistrictName} {Zipcode}',
                                '</li>',
                            '</tpl>',
                        '</ul>'
                    ],
                    displayTpl: [
                            '<tpl for=".">',
                                    '{ProvinceName} {DistrictName} {SubdistrictName} {Zipcode}',
                            '</tpl>',
                    ],
                    minChars: 3,
                    //queryParam: 'text',
                    queryMode: 'local',
                    store: 'CommonData.provinces',
                    valueField: 'SubdistrictId',
                    //                    listeners: {
                    //                        textchange: 'onTextchange'
                    //                    }
                    doQuery: function (queryString, forceAll) {
                        console.log(queryString);
                        this.expand();
                        this.store.clearFilter();
                        if (!forceAll) {
                            
                            var filters = [
                                         new Ext.util.Filter({
                                             filterFn: function (item) {
                                                 //allmatch
                                                 //return item.get('ProvinceName') == queryString || item.get('DistrictName') == queryString || item.get('SubdistrictName') == queryString || item.get('Zipcode') == queryString;
                                                 //anymatch
                                                 //return new RegExp(queryString, "i").test(item.get('ProvinceName')) || new RegExp(queryString, "i").test(item.get('DistrictName')) || new RegExp(queryString, "i").test(item.get('SubdistrictName')) || new RegExp(queryString, "i").test(item.get('Zipcode'));

                                                 if(new RegExp(queryString, "i").test(item.get('Zipcode'))){
                                                    return true;
                                                 }else if(new RegExp(queryString, "i").test(item.get('SubdistrictName'))){
                                                    return true;
                                                 }else if(new RegExp(queryString, "i").test(item.get('DistrictName'))){
                                                    return true;
                                                 }else if(new RegExp(queryString, "i").test(item.get('ProvinceName'))){
                                                    return true;
                                                 }else{
                                                    false;
                                                 }


                                             }
                                         })
                                    ];
                            this.store.filter(filters);

                        }
                    }
                },
                {
                    xtype: 'textfield',
                    colspan: 2,
                    fieldLabel: 'Other Zipcode',
                    labelAlign: 'right',
                    name: 'OtherZipcode',
                    emptyText: '[รหัสไปรษณีย์อื่นๆ]'
                },
                {
                    xtype: 'checkboxfield',
                    fieldLabel: 'Active',
                    name: 'Active',
                    labelAlign: 'right',
                    checked: true,
                    inputValue: 1
                }
            ],
            dockedItems: [
                {
                    xtype: 'toolbar',
                    dock: 'bottom',
                    ui: 'footer',
                    items: [
                        {
                            xtype: 'button',
                            text: 'Save',
                            listeners: {
                                click: 'onButtonSaveClick'
                            }
                        },
                        {
                            xtype: 'button',
                            text: 'Cancel',
                            listeners: {
                                click: 'onButtonCancelClick'
                            }
                        }
                    ]
                }
            ]
        }
    ]

});