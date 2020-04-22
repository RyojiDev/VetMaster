using System.Data.Entity.ModelConfiguration;

namespace RyojiKitano.AcessaADados.Common.Entity
{
    public abstract class EntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade : class
    {
        public EntityAbstractConfig()
        {
            ConfigurarNomeTabela();
            ConfigurarCampoTabela();
            ConfigurarChavePrimaria();
            ConfigurarChavesEstrangeiras();
        }

        protected abstract void ConfigurarNomeTabela();
        protected abstract void ConfigurarCampoTabela();
        protected abstract void ConfigurarChavePrimaria();
        protected abstract void ConfigurarChavesEstrangeiras();
       

    }
}
