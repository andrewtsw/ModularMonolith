namespace TCO.SNT.Entities
{
    /// <summary>
    /// Перемещение товара (A 9)
    /// </summary>
    public enum SntTransferType
    {
        /// <summary>
        /// В пределах одного лица на территории РК (A 9.1)
        /// </summary>
        ONE_PERSON_IN_KZ,

        /// <summary>
        /// В пределах одного лица в рамках ЕАЭС (A 9.2)
        /// </summary>
        ONE_PERSON_IN_EAEU,

        /// <summary>
        /// Иное перемещение (A 9.3)
        /// </summary>
        OTHER
    }
}
