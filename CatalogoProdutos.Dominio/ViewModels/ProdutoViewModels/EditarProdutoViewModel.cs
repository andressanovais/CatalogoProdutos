using Flunt.Notifications;
using Flunt.Validations;

namespace CatalogoProdutos.Dominio.ViewModels.ProdutoViewModels
{
    public class EditarProdutoViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMaxLen(Nome, 200, "Nome", "O nome deve conter até 200 caracteres")
                .IsNotNullOrEmpty(Nome, "Nome", "Nome obrigatório")
                .HasMaxLen(Marca, 100, "Marca", "A marca deve conter até 100 caracteres")
                .IsNotNullOrEmpty(Marca, "Marca", "Marca obrigatória")
                .IsGreaterOrEqualsThan(Preco, 0, "Preco", "Preço inválido")
                );
        }
    }
}
