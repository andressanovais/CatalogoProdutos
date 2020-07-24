using Flunt.Notifications;
using Flunt.Validations;

namespace CatalogoProdutos.Dominio.ViewModels.CategoriaViewModels
{
    public class EditarCategoriaViewModel : Notifiable, IValidatable
    {
        public string Nome { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .IsNotNullOrEmpty(Nome, "Nome", "Categoria inválida")
                .IsNotNullOrWhiteSpace(Nome, "Nome", "Categoria inválida")
                .HasMaxLen(Nome, 50, "Nome", "Categoria deve conter até 50 caracteres.")
                );
        }
    }
}
