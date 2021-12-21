$(document).ready(function () {
    var menu = document.getElementById("navProdutos");
    AtivarMenuNavegacao(menu);

    //console.log(data());
    /*https://datatables.net/plug-ins/i18n/*/
    //PT-PT :: https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_pt.json
    $('#tblProdutos').DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_br.json'
        },
        "ajax": "https://localhost:44392/api/Livro",
        "columns": [
            { "data": "id" },
            { "data":"nome" },
            { "data":"autor" },
            { "data":"formato" },
            { "data":"idioma" },
            { "data":"quantidadeEmEstoque" },
            { "defaultContent": "<a href='#'>Editar Detalhes</a>" },

        ]
    });
});

