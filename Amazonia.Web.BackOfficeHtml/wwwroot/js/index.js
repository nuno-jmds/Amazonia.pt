function AtualizarValoresPaineis() {
    $("#lblNumeroVendas").text("0");
    $("#lblNumeroVendasCanceladas").text("0");
    $("#lblClientesNovos").text("0");
    $("#lblLivrosAesgotar").text("0");


}

$(document).ready(function () {
    var menu = document.getElementById("navHome");
    AtivarMenuNavegacao(menu);
    AtualizarValoresPaineis();

    $("#btnLogin").click(function () {
        ExibirPainelDeLogin();
    });
});


function ExibirPainelDeLogin() {
    Swal.fire({
        title: 'Submit your Github username',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Logar',
        showLoaderOnConfirm: true,
        preConfirm: (login) => {
            return fetch(`//api.github.com/users/${login}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error(response.statusText)
                    }
                    return response.json()
                })
                .catch(error => {
                    Swal.showValidationMessage(
                        `Request failed: ${error}`
                    )
                })
        },
        allowOutsideClick: () => !Swal.isLoading()
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: `${result.value.login}'s avatar`,
                imageUrl: result.value.avatar_url
            })
        }
    })
}
