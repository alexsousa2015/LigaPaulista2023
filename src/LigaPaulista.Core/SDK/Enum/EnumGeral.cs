namespace LigaPaulista.Core.SDK.Enum
{
    public enum TipoLoad
    {
        Include = 1,
        List = 2
    }

    public enum EventoInscricao
    {
        AguardandoValidacao = 1,
        AguardandoDocumentos = 2,
        DocumentosConfirmados = 3,
        DocumentosEntregues = 4,
        InscricaoCancelada = 5,
        StatusNd = 0,
    }

    #region DbParameter
    public enum EnumDataAccessMetodo
    {
        Get = 1,
        Update = 2,
        Insert = 3,
        Delete = 4
    }
    #endregion
}
