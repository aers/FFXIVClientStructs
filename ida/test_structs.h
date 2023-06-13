struct Client::Game::Event::EventId;

struct Client::Game::Event::EventId /* Size=0x4 */
{
    union
    {
        /* 0x0 */ unsigned __int32 Id;
        struct
        {
            /* 0x0 */ unsigned __int16 EntryId;
            /* 0x2 */ unsigned __int16 Type;
        } _struct_0x0;
    } _union_0x0;
};