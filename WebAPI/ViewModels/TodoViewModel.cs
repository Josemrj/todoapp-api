namespace WebAPI.ViewModels
{
    public class TodoViewModel
    {
        public string Id { get; set; }
        public DateTime DataConclusao { get; set; }
        public string Descricao { get; set; }
        public bool IsConcluido { get; set; }
    }
}
