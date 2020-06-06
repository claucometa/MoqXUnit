namespace MoqXUnit
{
    public class BusinessContext
    {
        public readonly IProdutoRepo produtoRepo;
        public readonly Workflow workflow;

        public BusinessContext(IProdutoRepo produtoRepo, Workflow workflow)
        {
            this.produtoRepo = produtoRepo;
            this.workflow = workflow;
        }
    }
}