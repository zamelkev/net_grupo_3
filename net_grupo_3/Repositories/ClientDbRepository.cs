namespace net_grupo_3.Repositories;
public class ClientDbRepository : IClientRepository
{


    private AppDbContext Context;



    public ClientDbRepository(AppDbContext context)
    {
        Context = context;

    }

    // métodos
    public Client FindById(int id)
    {
        return Context.Client.Find(id);
    }

    public List<Client> FindAll()
    {
        return Context.Client.ToList();
    }


}
