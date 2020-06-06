namespace MoqXUnit
{
    public class BusinessContext
    {
        public readonly IProdutoRepo ProdutoRepo;
        public readonly Workflow Workflow;

        public BusinessContext(IProdutoRepo ProdutoRepo, Workflow Workflow)
        {
            this.ProdutoRepo = ProdutoRepo;
            this.Workflow = Workflow;
        }
    }
}