namespace TCO.SNT.Entities
{
    /// <summary>
    /// Вид транспорта (E 39.1)
    /// </summary>
    public enum SntTransporterTransportType
    {
        /// <summary>
        /// Автомобильный (а)
        /// </summary>
        AUTOMOBILE,

        /// <summary>
        /// Железнодорожный (b)
        /// </summary>
        RAILWAY,

        /// <summary>
        /// Воздушный (c)
        /// </summary>
        AIR,

        /// <summary>
        /// Морской или внутренний водный (d)
        /// </summary>
        MARINE,

        /// <summary>
        /// Трубопровод (e)
        /// </summary>
        PIPELINE,

        /// <summary>
        /// Мультимодальный (f)
        /// </summary>
        MULTIMODAL
    }
}
