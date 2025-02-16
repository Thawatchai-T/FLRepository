/*
* File: app/view/Job/Application/Tab/ApplicationViewController.js
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

Ext.define('TabUserInformation.view.Job.Application.Tab.ApplicationViewController', {
    extend: 'Ext.app.ViewController',
    alias: 'controller.jobapplicationtabapplication',

    onEquipmentListTriggerClick: function (field, trigger, e) {
        var grid = field.up('grid'),
            record = grid.getSelection()[0],
            rowedit = grid.getPlugin('rowedit'),
            value = grid.ownerCt.down('#TypeEquipment').getRawValue();

        if (value != '0') {
            if (e.type == 'click') {
                var popup = Ext.create('widget.jobapplicationwindowequipmentdetail', {
                    listeners: {
                        beforerender: function (panel, eOpts) {
                            panel.getController().HideAndShow(value);
                            panel.down('form').getForm().loadRecord(record);
                        },
                        beforeclose: function (panel, eOpts) {
                            var form = panel.down('form').getForm(),
                                store = panel.down('grid').getStore(),
                                record = panel.down('grid').getSelection()[0];

                            if (record) {
                                form.updateRecord(record);
                            }

                            if (panel.closeMe) {
                                panel.closeMe = false;
                                return true;
                            }

                            if (store.getModifiedRecords()) {
                                Ext.Msg.show({
                                    title: 'Save Changes?',
                                    message: 'คุณต้องการบันทึกข้อมูลหรือไม่?',
                                    buttons: Ext.Msg.YESNOCANCEL,
                                    icon: Ext.Msg.QUESTION,
                                    width: 300,
                                    fn: function (btn) {
                                        if (btn === 'yes') {
                                            store.sync();
                                            panel.closeMe = true;
                                            panel.close();
                                        } else if (btn === 'no') {
                                            panel.closeMe = true;
                                            panel.close();
                                        } else {
                                        }
                                    }
                                });
                            }

                            return false;
                        }
                    }
                });
                popup.center();
                popup.show();
            }
        }
    },

    onButtonDefineAddressClick: function (button, e, eOpts) {

        var popup = Ext.create('widget.jobapplicationwindowdefineaddress');
        //     record = this.getView(),
        //     form = popup.down('form').getForm();

        // console.log(record);
        // form.loadRecord(record);
        console.log(this.getView().getForm().findField('Id').getValue());
        popup.show();
    },

    onButtonSignerClick: function (button, e, eOpts) {
        var view = this.getView(),
            form = view.down('form').getForm(),
            store = this.getView().down('gridpanel').getStore();

        var popup = Ext.create('widget.commonsignerpopup', {
            listeners: {
                close: function (panel, eOpts) {
                    var record2 = panel.down('gridpanel').getSelection()[0];
                    if (record2) {
                        //                         form.loadRecord(record);

                        //                 store.add({
                        //                     SellerName: record2.get('NameEn')
                        //                 });
                    }
                }
            }
        });
        popup.show();
    },

    onButtonSignerClick2: function (button, e, eOpts) {
        var view = this.getView(),
            form = view.down('form').getForm(),
            store = this.getView().down('gridpanel').getStore();

        var popup = Ext.create('widget.commonsignerpopup', {
            listeners: {
                close: function (panel, eOpts) {
                    var record2 = panel.down('gridpanel').getSelection()[0];
                    if (record2) {
                        //                         form.loadRecord(record);

                        //                 store.add({
                        //                     SellerName: record2.get('NameEn')
                        //                 });
                    }
                }
            }
        });
        popup.show();
    },

    onButtonSignerClick3: function (button, e, eOpts) {
        var view = this.getView(),
            form = view.down('form').getForm(),
            store = this.getView().down('gridpanel').getStore();

        var popup = Ext.create('widget.commonsignerpopup', {
            listeners: {
                close: function (panel, eOpts) {
                    var record2 = panel.down('gridpanel').getSelection()[0];
                    if (record2) {
                        //                         form.loadRecord(record);

                        //                 store.add({
                        //                     SellerName: record2.get('NameEn')
                        //                 });
                    }
                }
            }
        });
        popup.show();
    },

    onButtonApprovalClick: function (button, e, eOpts) {
        var popup = Ext.create('widget.jobapplicationwindowapproval');
        popup.show();
    },

    onNumberfieldVatChange: function (field, newValue, oldValue, eOpts) {
        if (oldValue) {
            var object = Ext.decode(sessionStorage.getItem('AppDetail'));
            object.VAT = newValue;
            sessionStorage.setItem('AppDetail', Ext.encode(object));
        }
    },

    onGridpanelItemDblClick: function (dataview, record, item, index, e, eOpts) {
        var view = this.getView();
        var value = this.getView().down('#TypeEquipment').getRawValue();

        var popup = Ext.create('widget.jobapplicationwindowequipmentdetail', {
            listeners: {
                beforerender: function (panel, eOpts) {
                    panel.getController().HideAndShow(value);
                    panel.down('form').getForm().loadRecord(record);
                },
                beforeclose: function (panel, eOpts) {
                    var form = panel.down('form').getForm(),
                                store = panel.down('grid').getStore(),
                                record = panel.down('grid').getSelection()[0];

                    if (record) {
                        form.updateRecord(record);
                    }

                    if (panel.closeMe) {
                        panel.closeMe = false;
                        return true;
                    }

                    if (store.getModifiedRecords()) {
                        Ext.Msg.show({
                            title: 'Save Changes?',
                            message: 'คุณต้องการบันทึกข้อมูลหรือไม่?',
                            buttons: Ext.Msg.YESNOCANCEL,
                            icon: Ext.Msg.QUESTION,
                            width: 300,
                            fn: function (btn) {
                                if (btn === 'yes') {
                                    store.sync();
                                    panel.closeMe = true;
                                    panel.close();
                                } else if (btn === 'no') {
                                    panel.closeMe = true;
                                    panel.close();
                                } else {
                                }
                            }
                        });
                    }

                    return false;
                },
                close: function (panel, eOpts) {
                    view.down('grid').getStore().load();
                }
            }
        });
        popup.center();
        popup.show();
    },

    onGridpanelSelectionChange: function (model, selected, eOpts) {
        var form = this.getView().getForm();

        // form.findField('DepositDownPayment').setValue(selected[0].get(''));
        // form.findField('DepositDownVAT').setValue(selected[0].get(''));
        // form.findField('DepositDownTotal').setValue(selected[0].get(''));
        // form.findField('DepositEquivalent').setValue(selected[0].get(''));
        form.findField('EquipmentCost').setValue(selected[0].get('UnitPrice'));
        form.findField('EquipmentVAT').setValue(selected[0].get('VAT'));
        form.findField('EquipmentTotal').setValue(selected[0].get('UnitPrice') + selected[0].get('VAT'));
        form.findField('CostEquivalent').setValue(selected[0].get(''));
    },

    onButtonNewLineClick: function (button, e, eOpts) {
        var view = this.getView();
        var value = this.getView().down('#TypeEquipment').getRawValue();
        var store = this.getView().down('grid').getStore(),
            record = Ext.create('model.equipmentlist', {
                ApplicationDetail: {
                    Id: Ext.decode(sessionStorage.getItem('AppDetail')).Id
                }
            });

        record.data.Id = 0;
        store.add(record);
        var popup = Ext.create('widget.jobapplicationwindowequipmentdetail', {
            listeners: {
                beforerender: function (panel, eOpts) {
                    panel.getController().HideAndShow(value);
                    panel.down('form').getForm().loadRecord(record);
                },
                beforeclose: function (panel, eOpts) {
                    var form = panel.down('form').getForm(),
                                store = panel.down('grid').getStore(),
                                record = panel.down('grid').getSelection()[0];

                    if (record) {
                        form.updateRecord(record);
                    }

                    if (panel.closeMe) {
                        panel.closeMe = false;
                        return true;
                    }

                    if (store.getModifiedRecords()) {
                        Ext.Msg.show({
                            title: 'Save Changes?',
                            message: 'คุณต้องการบันทึกข้อมูลหรือไม่?',
                            buttons: Ext.Msg.YESNOCANCEL,
                            icon: Ext.Msg.QUESTION,
                            width: 300,
                            fn: function (btn) {
                                if (btn === 'yes') {
                                    store.sync();
                                    panel.closeMe = true;
                                    panel.close();
                                } else if (btn === 'no') {
                                    panel.closeMe = true;
                                    panel.close();
                                } else {
                                }
                            }
                        });
                    }

                    return false;
                },
                close: function (panel, eOpts) {
                    view.down('grid').getStore().load();
                }
            }
        });
        popup.center();
        popup.show();

    },

    onButtonDeleteLineClick: function (button, e, eOpts) {
        var store = this.getView().down('grid').getStore(),
            record = this.getView().down('grid').getSelection()[0];

        if (record) {
            if (record.get('Id') != '0') {
                Ext.MessageBox.confirm('Confirm', 'Confirm Delete?',
                function (msg) {
                    if (msg == 'yes') {
                        store.remove(record);
                    }
                }, this);
            } else {
                store.remove(record);
            }
        }

    },

    onStoreBeforeLoad: function (store, operation, eOpts) {
        var Id = Ext.decode(sessionStorage.getItem('AppDetail')).Id;
        store.getProxy().extraParams.id = Id;
        store.getProxy().extraParams.name = 'EquipmentList';
    },

    onStoreSellerBeforeLoad: function (store, operation, eOpts) {
        store = Ext.getCmp('jobapplicationtabseller').down('grid').getStore();
        console.log(store);
    }

});
