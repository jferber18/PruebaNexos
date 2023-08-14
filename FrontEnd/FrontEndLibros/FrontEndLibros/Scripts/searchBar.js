/*
$(document).on("ready", function(){
	
    $(".table-special>tbody tr").addClass("ChildClick");
    $(".table-special>tbody tr").attr("onclick", "ChildClick(this)");
	tableSpecial();
})
*/

function UseDataTables() {
    $(".table-special").siblings(".searchBar").remove();
    var table = $(".table-special").DataTable({
        language: { url: "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        //dom: 'BFRTIP',
        //tableTools: { sSwfPath: "/Content/DataTables/swf/flashExport.swf" },
        responsive: true,
        autoWidth: false,
        //bStateSave: true,
        dom: 'Blftipr',
        buttons: [
                {
                    extend: 'pdfHtml5',
                    text: 'Exportar a PDF',
                    exportOptions: {
                        modifier: {
                            page: 'current'
                        }
                    }
                },
                {
                    extend: 'excelHtml5',
                    text: 'Exportar a Excel',
                    exportOptions: {
                        modifier: {
                            page: 'current'
                        }
                    }
                }
        ]
    });
    table.buttons().container().appendTo($('.DataTablesBtn:eq(0)', table.table().container()));
}

function filtrarTabla(event) {
    if (event.target.value.length > 0) {
        var _toFindText = event.target.value;
        $(event.target).siblings(".clean").fadeIn();
        //console.log($(event.target).parents(".searchBar").siblings(".table-special").find(" tbody tr")[0]);
        $(event.target).parents(".searchBar").siblings(".table-special").find(" tbody tr").each(function () {
            if ($(this).children("td").length > 0) {
                 if ($(this).prop("textContent").toLowerCase().indexOf(_toFindText.toLowerCase()) == -1)
                 {
                     $(this).fadeOut();
                 }
                 else {
                     $(this).fadeIn();
                 }
                }
         });
    } else {
        $(event.target).siblings(".clean").fadeOut();
        $(event.target).parents(".searchBar").siblings(".table-special").find("tbody tr").fadeIn();
    }
}
function tableSpecial() {
    $(".table-special").not(".dataTable").before(
                             $("<div class='searchBar'></div>").append(
                                            $(" <input type='text' placeholder='Buscar..'>").on("keyup change blur", filtrarTabla)
                                            ).append($("<i class='clean' style='display: none;'>&#61527;</i>").on("click", function () { $(this).fadeOut().siblings('input').val('');
                                            $(this).parents(".searchBar").siblings(".table-special").find("tbody tr").fadeIn();
                                            }))
                        );
}

function searchBar(options) {
    var defaults = {
        selector: "",
        contenerClass: "",
        inputClass: "",
        noResultsClass: "",
        inputPlaceholder: "Buscar...",
        manual: false,
        limitar: false,
        blocks: 6
    };
    if (options == undefined) {
        options = defaults;
    }
    //roundedSearch
    options = $.extend(defaults, options);
    //console.log(options);
    var _target
    _target = $(".searchBar-filter").not(".manual-search").not(".dataTable");
    if (options.manual == true) {
        _target = $(".searchBar-filter.manual-search");
    }
    if (options.selector != "") {
        _target = $(selector);
    }

    _target.each(function () {

        $(this).before(
                                 $("<div class='searchBar'></div>").append(
                                                $(" <input type='text' placeholder='" + options.inputPlaceholder + "'>").addClass(options.inputClass).on("keyup change blur", filtrarElemento)
                                                ).append($("<i class='clean' style='display: none;'>&#61527;</i>").on("click", function () {
                                                    $(this).fadeOut().siblings('input').val('');
                                                    $(this).parents(".searchBar").siblings(".searchBar-filter").find(".searchBar-option").fadeIn();
                                                    $(this).parents(".searchBar").siblings(".searchBar-filter").next(".showMore").remove();

                                                    if (($(this).parents(".searchBar").siblings(".searchBar-filter").find(".searchBar-option").length > 10) && options.limitar == true) {
                                                        showMore($(this).parents(".searchBar").siblings(".searchBar-filter")[0], options.blocks);
                                                    }
                                                }))
                            );
        if (options.limitar == true) {
            showMore($(this), options.blocks);
        }

    });

}
function filtrarElemento(event) {
    var hiddenResults = 0;
    $(event.target).parents(".searchBar").siblings(".searchBar-noResults").remove();
    $(event.target).parents(".searchBar").siblings(".showMore").remove();

    if (event.target.value.length > 0) {
        var _toFindText = event.target.value;
        $(event.target).siblings(".clean").fadeIn();
        //console.log($(event.target).parents(".searchBar").siblings(".table-special").find(" tbody tr")[0]);
        $(event.target).parents(".searchBar").siblings(".searchBar-filter").find(".searchBar-option").each(function () {
            if ($(this).children("*").length > 0) {
                if ($(this).prop("textContent").toLowerCase().indexOf(_toFindText.toLowerCase()) == -1) {
                    $(this).fadeOut();
                    hiddenResults++;
                }
                else {
                    $(this).fadeIn();
                }
            }
        });
        if ($(event.target).parents(".searchBar").siblings(".searchBar-filter").find(".searchBar-option").length == hiddenResults)
        {
            $(event.target).parents(".searchBar").siblings(".searchBar-filter").before($("<div class='searchBar-noResults'>").text("No se han hallado resultados"));
            $(event.target).parents(".searchBar").siblings(".searchBar-filter").before($("<div class='searchBar-noResults'>").attr("style", "color: Black;"));
        }
    } else {
        $(event.target).siblings(".clean").fadeOut();
        $(event.target).parents(".searchBar").siblings(".searchBar-filter").find(".searchBar-option").fadeIn();
        showMore($(event.target).parents(".searchBar").siblings(".searchBar-filter")[0], 6);
    }
}
function showMore(element, blocks) {
    if ($(element).next().hasClass("showMore")) {
        console.log();
        return;
    }
    //blocks = blocks == undefined ? 6 : blocks;
    //$(element).children(":nth-child(6)").nextAll().each(function () { $(this).fadeOut(); });
    $(element).children(":nth-child("+blocks+")").nextAll().hide();;
    if ($(element).children(":hidden").length > 0) {
        $(element).after($("<div class='showMore'></div>").text(decodeURI("Mostrar%20m%C3%A1s")).data("blocks", blocks).on("click", function () {
            var blocks = $(this).data("blocks");

            $(this).prev().children(":hidden").slice(0, blocks).each(function () { $(this).fadeIn(); });
            if ($(this).prev().children(":hidden").length > 0 && $(this).prev().children(":hidden").length < blocks) {
                $(this).prev().children(":hidden").each(function () { $(this).fadeIn(); });
                $('html,body').animate({
                    scrollTop: $(this).offset().top - (parseInt($(this).offset().top) - window.scrollY)
                }, 0);
                $(this).remove();
            } else {
                $('html,body').animate({
                    scrollTop: $(this).offset().top - (parseInt($(this).offset().top) - window.scrollY)
                    //scrollTop: $(this).offset().top
                }, 0);
            }
        }));
    }
}








