namespace FCS.Virk
{
    public static class VrQueryValidator
    {
        public static bool ValidateVrQuery(VrQuery query)
        {
            // Precise lookup
            if (!string.IsNullOrEmpty(query.VatNumber)) return true;
            // Search lookup
            return !string.IsNullOrWhiteSpace(query.StreetName) 
                   && !string.IsNullOrWhiteSpace(query.HouseNumber) 
                   && !string.IsNullOrEmpty(query.ZipCode);
        }
    }
}