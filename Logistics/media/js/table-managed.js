var TableManaged = function () {

    return {

        //main function to initiate the module
        init: function () {
            
            if (!jQuery().dataTable) {
                return;
            }

            //// begin first table
            //$('#sample_1').dataTable({
            //    "aoColumns": [
            //      { "bSortable": false },
            //      null,
            //      { "bSortable": false },
            //      null,
            //      { "bSortable": false },
            //      { "bSortable": false }
            //    ],
            //    "aLengthMenu": [
            //        [5, 15, 20, -1],
            //        [5, 15, 20, "All"] // change per page values here
            //    ],
            //    // set the initial value
            //    "iDisplayLength": 5,
            //    "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
            //    "sPaginationType": "bootstrap",
            //    "oLanguage": {
            //        "sLengthMenu": "_MENU_ records per page",
            //        "oPaginate": {
            //            "sPrevious": "Prev",
            //            "sNext": "Next"
            //        }
            //    },
            //    "aoColumnDefs": [{
            //            'bSortable': false,
            //            'aTargets': [0]
            //        }
            //    ]
            //});

            //jQuery('#sample_1 .group-checkable').change(function () {
            //    var set = jQuery(this).attr("data-set");
            //    var checked = jQuery(this).is(":checked");
            //    jQuery(set).each(function () {
            //        if (checked) {
            //            $(this).attr("checked", true);
            //        } else {
            //            $(this).attr("checked", false);
            //        }
            //    });
            //    jQuery.uniform.update(set);
            //});

            //jQuery('#sample_1_wrapper .dataTables_filter input').addClass("m-wrap medium"); // modify table search input
            //jQuery('#sample_1_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
            ////jQuery('#sample_1_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

            //// begin second table
            //$('#sample_2').dataTable({
            //    "aLengthMenu": [
            //        [5, 15, 20, -1],
            //        [5, 15, 20, "All"] // change per page values here
            //    ],
            //    // set the initial value
            //    "iDisplayLength": 5,
            //    "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
            //    "sPaginationType": "bootstrap",
            //    "oLanguage": {
            //        "sLengthMenu": "_MENU_ per page",
            //        "oPaginate": {
            //            "sPrevious": "Prev",
            //            "sNext": "Next"
            //        }
            //    },
            //    "aoColumnDefs": [{
            //            'bSortable': false,
            //            'aTargets': [0]
            //        }
            //    ]
            //});

            //jQuery('#sample_2 .group-checkable').change(function () {
            //    var set = jQuery(this).attr("data-set");
            //    var checked = jQuery(this).is(":checked");
            //    jQuery(set).each(function () {
            //        if (checked) {
            //            $(this).attr("checked", true);
            //        } else {
            //            $(this).attr("checked", false);
            //        }
            //    });
            //    jQuery.uniform.update(set);
            //});

            //jQuery('#sample_2_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
            //jQuery('#sample_2_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
            //jQuery('#sample_2_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

            //// begin: third table
            //$('#sample_3').dataTable({
            //    "aLengthMenu": [
            //        [5, 15, 20, -1],
            //        [5, 15, 20, "All"] // change per page values here
            //    ],
            //    // set the initial value
            //    "iDisplayLength": 5,
            //    "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
            //    "sPaginationType": "bootstrap",
            //    "oLanguage": {
            //        "sLengthMenu": "_MENU_ per page",
            //        "oPaginate": {
            //            "sPrevious": "Prev",
            //            "sNext": "Next"
            //        }
            //    },
            //    "aoColumnDefs": [{
            //            'bSortable': false,
            //            'aTargets': [0]
            //        }
            //    ]
            //});

            //jQuery('#sample_3 .group-checkable').change(function () {
            //    var set = jQuery(this).attr("data-set");
            //    var checked = jQuery(this).is(":checked");
            //    jQuery(set).each(function () {
            //        if (checked) {
            //            $(this).attr("checked", true);
            //        } else {
            //            $(this).attr("checked", false);
            //        }
            //    });
            //    jQuery.uniform.update(set);
            //});

            //jQuery('#sample_3_wrapper .dataTables_filter input').addClass("m-wrap small"); // modify table search input
            //jQuery('#sample_3_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
            //jQuery('#sample_3_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown


            //getPackage table
            $('#sample_getPackage').dataTable({
                "aoColumns": [
                  { "bSortable": false },
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  { "bSortable": false }
                ],
                "aLengthMenu": [
                    [5, 10, 15, 20, -1],
                    [5, 10, 15, 20, "All"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 10,
                "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ per page",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [0]
                }
                ]
            });

            jQuery('#sample_getPackage .group-checkable').change(function () {
                var set = jQuery(this).attr("data-set");
                var checked = jQuery(this).is(":checked");
                jQuery(set).each(function () {
                    if (checked) {
                        $(this).attr("checked", true);
                    } else {
                        $(this).attr("checked", false);
                    }
                });
                jQuery.uniform.update(set);
            });

            jQuery('#sample_getPackage_wrapper .dataTables_filter input').addClass("m-wrap medium"); // modify table search input
            jQuery('#sample_getPackage_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
            //jQuery('#sample_getPackage_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown


            //StockInfo table
            $('#sample_stockInfo').dataTable({
                "aoColumns": [
                  { "bSortable": false },
                  null,
                  null,                 
                  { "bSortable": false }
                ],
                "aLengthMenu": [
                    [5, 10, 15, 20, -1],
                    [5, 10, 15, 20, "All"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 10,
                "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ per page",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [0]
                }
                ]
            });

            jQuery('#sample_stockInfo .group-checkable').change(function () {
                var set = jQuery(this).attr("data-set");
                var checked = jQuery(this).is(":checked");
                jQuery(set).each(function () {
                    if (checked) {
                        $(this).attr("checked", true);
                    } else {
                        $(this).attr("checked", false);
                    }
                });
                jQuery.uniform.update(set);
            });

            jQuery('#sample_stockInfo_wrapper .dataTables_filter input').addClass("m-wrap medium"); // modify table search input
            jQuery('#sample_stockInfo_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
            //jQuery('#sample_getPackage_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

            //4 table
            $('#sample_4').dataTable({
                "aoColumns": [
                  { "bSortable": false },
                  null,
                  null,
                  null,
                  null,
                  { "bSortable": false }
                ],
                "aLengthMenu": [
                    [5, 10, 15, 20, -1],
                    [5, 10, 15, 20, "All"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 10,
                "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ per page",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [0]
                }
                ]
            });

            jQuery('#sample_4 .group-checkable').change(function () {
                var set = jQuery(this).attr("data-set");
                var checked = jQuery(this).is(":checked");
                jQuery(set).each(function () {
                    if (checked) {
                        $(this).attr("checked", true);
                    } else {
                        $(this).attr("checked", false);
                    }
                });
                jQuery.uniform.update(set);
            });

            jQuery('#sample_4_wrapper .dataTables_filter input').addClass("m-wrap medium"); // modify table search input
            jQuery('#sample_4_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
            //jQuery('#sample_getPackage_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

            //7 table
            $('#sample_7').dataTable({
                "aoColumns": [
                  { "bSortable": false },
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                  { "bSortable": false }
                ],
                "aLengthMenu": [
                    [5, 10, 15, 20, -1],
                    [5, 10, 15, 20, "All"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 10,
                "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ per page",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [0]
                }
                ]
            });

            jQuery('#sample_7 .group-checkable').change(function () {
                var set = jQuery(this).attr("data-set");
                var checked = jQuery(this).is(":checked");
                jQuery(set).each(function () {
                    if (checked) {
                        $(this).attr("checked", true);
                    } else {
                        $(this).attr("checked", false);
                    }
                });
                jQuery.uniform.update(set);
            });

            jQuery('#sample_7_wrapper .dataTables_filter input').addClass("m-wrap medium"); // modify table search input
            jQuery('#sample_7_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
            //jQuery('#sample_getPackage_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown


            //sample_deliveryInfo table
            $('#sample_deliveryInfo').dataTable({
                "aoColumns": [
                  { "bSortable": false },
                  null,
                  null,
                  null,
                  null,
                  null,
                  null,
                ],
                "aLengthMenu": [
                    [5, 10, 15, 20, -1],
                    [5, 10, 15, 20, "All"] // change per page values here
                ],
                // set the initial value
                "iDisplayLength": 10,
                "sDom": "<'row-fluid'<'span6'l><'span6'f>r>t<'row-fluid'<'span6'i><'span6'p>>",
                "sPaginationType": "bootstrap",
                "oLanguage": {
                    "sLengthMenu": "_MENU_ per page",
                    "oPaginate": {
                        "sPrevious": "Prev",
                        "sNext": "Next"
                    }
                },
                "aoColumnDefs": [{
                    'bSortable': false,
                    'aTargets': [0]
                }
                ]
            });

            jQuery('#sample_deliveryInfo .group-checkable').change(function () {
                var set = jQuery(this).attr("data-set");
                var checked = jQuery(this).is(":checked");
                jQuery(set).each(function () {
                    if (checked) {
                        $(this).attr("checked", true);
                    } else {
                        $(this).attr("checked", false);
                    }
                });
                jQuery.uniform.update(set);
            });

            jQuery('#sample_deliveryInfo_wrapper .dataTables_filter input').addClass("m-wrap medium"); // modify table search input
            jQuery('#sample_deliveryInfo_wrapper .dataTables_length select').addClass("m-wrap small"); // modify table per page dropdown
            //jQuery('#sample_getPackage_wrapper .dataTables_length select').select2(); // initialzie select2 dropdown

        }



    };

}(); 
