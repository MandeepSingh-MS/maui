static class CodeDataRepository
{

    static string CollectionName = "code_data";

    static string ENDPOINT = "https://db.us.fauna.com:443";
    // static string SECRET = "fnAEfiIddqAASZJTUCki837Xc4j2DilAaTaODr6z";
    static string SECRET = "fnAEfiQ3OZAASZRSZyfG7blkAlqLww7QdGyYabdO";
    static FaunaClient client = new FaunaClient(endpoint: ENDPOINT, secret: SECRET);

    public static RefV? after = null;

    public static Task<Value> GetCodeData()
    {
        return client.Query(
Map(
    Paginate(
            Documents(
                Collection(CollectionName)
            ),
            size: 2,
            after: after
    ),
            lambda: (a) =>
            {
                return Get(a);
            }

            )
        );

    }




    public static Task<Value> AddCodeData(CodeData codeData)
    {
        return client.Query(
            Create(Collection(CollectionName),
            Obj("data", Encoder.Encode(codeData))
            )
        );
    }


    public static Task<Value> GetCodeDataWithTitleMatching(string text)
    {
        return client.Query(
Map(

Filter(
    Paginate(
            Match(Index("code_data_get_title_and_ref_from_docs")),
            size: 2
    // after: after
    ),
lambda: (title, refe) =>
{
    return ContainsStr(title, text);
}
), lambda: (a, uu) =>
   {

       return Get(uu);
   }

            )
        );

    }
}


