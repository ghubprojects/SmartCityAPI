namespace SmartCity.Infrastructure.Utils;

public static class SeedUtil {
    private static readonly Dictionary<string, (string, string)> places = new() {
        { "archaeological", ("di tích khảo cổ", "Di tích khảo cổ {0} là nơi lưu giữ các dấu vết của nền văn hóa cổ xưa, mang đến cái nhìn sâu sắc về lịch sử và phát triển của khu vực.") },
        { "arts_centre", ("trung tâm nghệ thuật", "Trung tâm nghệ thuật {0} là nơi tổ chức các buổi triển lãm và sự kiện nghệ thuật, mang đến không gian sáng tạo cho các nghệ sĩ và công chúng.") },
        { "artwork", ("tác phẩm nghệ thuật", "Tác phẩm nghệ thuật {0} thể hiện tài năng sáng tạo và cảm hứng nghệ sĩ, mang đến những thông điệp sâu sắc và gợi mở về thế giới xung quanh.") },
        { "atm", ("máy rút tiền", "Máy rút tiền {0} cung cấp dịch vụ rút tiền nhanh chóng và thuận tiện, giúp bạn dễ dàng truy cập tài khoản ngân hàng bất cứ lúc nào.") },
        { "attraction", ("điểm tham quan", "Điểm tham quan {0} là một địa điểm thu hút du khách nhờ vẻ đẹp tự nhiên hoặc giá trị văn hóa, lịch sử đặc biệt.") },
        { "bakery", ("tiệm bánh", "Tiệm bánh {0} mang đến những món bánh tươi ngon, thơm lừng, được làm từ nguyên liệu tươi mới, phù hợp cho những ai yêu thích các món ăn nhẹ và ngọt.") },
        { "bank", ("ngân hàng", "Ngân hàng {0} cung cấp các dịch vụ tài chính đa dạng, từ gửi tiền, vay vốn đến quản lý tài sản, với sự phục vụ chuyên nghiệp và an toàn.") },
        { "bar", ("quán bar", "Quán bar {0} là nơi lý tưởng để thư giãn và thưởng thức các loại đồ uống đa dạng trong một không gian sôi động và hiện đại.") },
        { "beauty_shop", ("tiệm làm đẹp", "Tiệm làm đẹp {0} cung cấp các dịch vụ chăm sóc sắc đẹp như cắt tóc, tạo kiểu, làm móng, và các liệu trình dưỡng da, giúp bạn luôn tự tin và tươi tắn.") },
        { "bench", ("ghế băng", "Ghế băng {0} là nơi lý tưởng để nghỉ ngơi và thư giãn, nằm trong không gian công cộng như công viên, khu vực ven đường hoặc khu shopping.") },
        { "beverages", ("thức uống", "Thức uống {0} mang đến một lựa chọn phong phú từ các loại nước giải khát mát lạnh, trà, cà phê đến các loại nước ép trái cây tươi ngon.") },
        { "bicycle_rental", ("cho thuê xe đạp", "Dịch vụ cho thuê xe đạp {0} mang đến cho bạn cơ hội khám phá thành phố hoặc thiên nhiên một cách tự do và dễ dàng.") },
        { "bicycle_shop", ("cửa hàng xe đạp", "Cửa hàng xe đạp {0} cung cấp một loạt các mẫu xe đạp từ cơ bản đến cao cấp, với các phụ kiện và dịch vụ sửa chữa chuyên nghiệp.") },
        { "biergarten", ("vườn bia", "Vườn bia {0} mang đến không gian thư giãn ngoài trời, nơi bạn có thể thưởng thức các loại bia tươi ngon cùng các món ăn nhẹ hấp dẫn trong bầu không khí thoải mái.") },
        { "bookshop", ("hiệu sách", "Hiệu sách {0} là nơi bạn có thể tìm thấy những cuốn sách từ các thể loại đa dạng, từ văn học, khoa học đến các tác phẩm nghệ thuật, đáp ứng nhu cầu đọc sách của mọi lứa tuổi.") },
        { "butcher", ("cửa hàng thịt", "Cửa hàng thịt {0} cung cấp các loại thịt tươi ngon, được chọn lọc kỹ lưỡng, với dịch vụ cắt và chế biến theo yêu cầu, mang đến sự tiện lợi cho các bữa ăn gia đình.") },
        { "cafe", ("quán cà phê", "Quán cà phê {0} mang đến không gian yên tĩnh và thoải mái để thưởng thức những ly cà phê thơm ngon và các món bánh nhẹ.") },
        { "camp_site", ("khu cắm trại", "Khu cắm trại {0} là nơi lý tưởng cho những ai yêu thích hoạt động ngoài trời, với không gian rộng rãi và thoáng mát, phù hợp cho những chuyến dã ngoại và khám phá thiên nhiên.") },
        { "car_dealership", ("cửa hàng ô tô", "Cửa hàng ô tô {0} cung cấp đa dạng các mẫu xe mới và đã qua sử dụng, từ các dòng xe gia đình đến các loại xe thể thao, với dịch vụ tư vấn và hỗ trợ tài chính chu đáo.") },
        { "car_rental", ("cho thuê xe ô tô", "Dịch vụ cho thuê xe ô tô {0} mang đến sự linh hoạt trong việc lựa chọn các dòng xe phù hợp cho các chuyến đi, từ xe nhỏ gọn đến các dòng xe sang trọng, giúp bạn di chuyển thuận tiện và an toàn.") },
        { "car_sharing", ("dịch vụ chia sẻ xe ô tô", "Dịch vụ chia sẻ xe ô tô {0} giúp bạn dễ dàng thuê xe theo giờ hoặc ngày, tiết kiệm chi phí và linh hoạt trong việc di chuyển mà không cần phải sở hữu xe.") },
        { "car_wash", ("trạm rửa xe", "Trạm rửa xe {0} cung cấp các dịch vụ rửa xe tự động và thủ công, giúp chiếc xe của bạn luôn sạch sẽ và bóng loáng trong mọi điều kiện thời tiết.") },
        { "caravan_site", ("khu vực cắm trại", "Khu vực cắm trại {0} là nơi lý tưởng để dừng chân và nghỉ ngơi trong những chuyến du lịch dài ngày, với các tiện ích như điện nước đầy đủ và không gian yên tĩnh.") },
        { "castle", ("lâu đài", "Lâu đài {0} mang đến không gian hoành tráng và lịch sử, là một điểm đến tuyệt vời để khám phá kiến trúc cổ xưa và tìm hiểu về văn hóa và lịch sử của khu vực.") },
        { "chalet", ("nhà nghỉ gỗ", "Nhà nghỉ gỗ {0} mang đến không gian ấm cúng và gần gũi với thiên nhiên, là lựa chọn lý tưởng cho những ai yêu thích sự yên tĩnh và thư giãn trong kỳ nghỉ.") },
        { "chemist", ("nhà thuốc", "Nhà thuốc {0} cung cấp đầy đủ các sản phẩm thuốc, dược phẩm, và các sản phẩm chăm sóc sức khỏe, với sự hướng dẫn và tư vấn chuyên môn từ các dược sĩ.") },
        { "cinema", ("rạp chiếu phim", "Rạp chiếu phim {0} mang đến trải nghiệm xem phim đỉnh cao với các bộ phim mới nhất, cùng với hệ thống âm thanh và hình ảnh sắc nét.") },
        { "clinic", ("phòng khám", "Phòng khám {0} cung cấp dịch vụ y tế chuyên nghiệp, từ khám bệnh định kỳ đến điều trị các vấn đề sức khỏe, với đội ngũ bác sĩ và nhân viên y tế tận tâm.") },
        { "clothes", ("cửa hàng quần áo", "Cửa hàng quần áo {0} mang đến các bộ sưu tập thời trang đa dạng, từ trang phục công sở đến trang phục thoải mái, phù hợp với mọi phong cách và nhu cầu.") },
        { "college", ("trường cao đẳng", "Trường cao đẳng {0} cung cấp các chương trình học chất lượng, giúp sinh viên phát triển kỹ năng chuyên môn và sẵn sàng bước vào thị trường lao động.") },
        { "comms_tower", ("tháp truyền thông", "Tháp truyền thông {0} là công trình quan trọng trong việc truyền tải sóng vô tuyến, giúp cung cấp dịch vụ viễn thông và truyền hình cho khu vực xung quanh.") },
        { "community_centre", ("trung tâm cộng đồng", "Trung tâm cộng đồng {0} là nơi tổ chức các hoạt động xã hội, sự kiện văn hóa và hỗ trợ các dịch vụ cho cộng đồng, tạo ra không gian kết nối và tương tác.") },
        { "computer_shop", ("cửa hàng máy tính", "Cửa hàng máy tính {0} cung cấp các sản phẩm công nghệ, từ máy tính để bàn, laptop đến các phụ kiện, với dịch vụ sửa chữa và hỗ trợ kỹ thuật chuyên nghiệp.") },
        { "convenience", ("cửa hàng tiện lợi", "Cửa hàng tiện lợi {0} mang đến các sản phẩm thiết yếu như thực phẩm, đồ uống, đồ dùng gia đình, phục vụ nhu cầu mua sắm nhanh chóng và tiện lợi.") },
        { "courthouse", ("tòa án", "Tòa án {0} là nơi xử lý các vụ án và bảo vệ quyền lợi hợp pháp của công dân, với đội ngũ thẩm phán và luật sư chuyên nghiệp.") },
        { "dentist", ("phòng nha khoa", "Phòng nha khoa {0} cung cấp các dịch vụ chăm sóc răng miệng, từ khám định kỳ, vệ sinh răng miệng đến điều trị các vấn đề nha khoa như sâu răng và niềng răng.") },
        { "department_store", ("cửa hàng bách hóa", "Cửa hàng bách hóa {0} là nơi bạn có thể tìm thấy một loạt các sản phẩm, từ quần áo, đồ gia dụng đến các món đồ công nghệ, đáp ứng mọi nhu cầu mua sắm của gia đình.") },
        { "doctors", ("phòng khám bác sĩ", "Phòng khám bác sĩ {0} cung cấp các dịch vụ khám và điều trị các bệnh lý, với đội ngũ bác sĩ giàu kinh nghiệm và trang thiết bị y tế hiện đại.") },
        { "doityourself", ("cửa hàng vật liệu xây dựng", "Cửa hàng vật liệu xây dựng {0} cung cấp các sản phẩm như sơn, gỗ, dụng cụ và vật liệu cần thiết cho các công trình tự làm, giúp bạn thực hiện các dự án sửa chữa và xây dựng một cách dễ dàng.") },
        { "embassy", ("đại sứ quán", "Đại sứ quán {0} cung cấp các dịch vụ lãnh sự cho công dân và hỗ trợ trong các vấn đề quốc tế, đảm bảo mối quan hệ ngoại giao giữa các quốc gia.") },
        { "fast_food", ("quán ăn nhanh", "Quán ăn nhanh {0} cung cấp các món ăn tiện lợi và ngon miệng như hamburger, pizza và các món chiên, phù hợp cho bữa ăn nhanh chóng trong một ngày bận rộn.") },
        { "fire_station", ("trạm cứu hỏa", "Trạm cứu hỏa {0} đảm bảo an toàn cho cộng đồng bằng cách cung cấp dịch vụ cứu hỏa nhanh chóng và chuyên nghiệp, cũng như xử lý các tình huống khẩn cấp khác.") },
        { "florist", ("cửa hàng hoa", "Cửa hàng hoa {0} cung cấp một loạt các loại hoa tươi, từ hoa sinh nhật, đám cưới đến các dịp đặc biệt, giúp bạn thể hiện tình cảm qua những bó hoa đẹp mắt.") },
        { "food_court", ("khu ẩm thực", "Khu ẩm thực {0} là nơi tập hợp nhiều quầy thức ăn, từ các món ăn địa phương đến ẩm thực quốc tế, đáp ứng nhu cầu ăn uống đa dạng cho thực khách.") },
        { "fort", ("pháo đài", "Pháo đài {0} là công trình lịch sử vững chãi, với kiến trúc độc đáo và các câu chuyện về quá khứ chiến tranh, thu hút du khách muốn khám phá lịch sử và văn hóa.") },
        { "fountain", ("đài phun nước", "Đài phun nước {0} tạo nên không gian tươi mát với dòng nước chảy liên tục, là điểm nhấn đẹp mắt trong các công viên, quảng trường và khu vực công cộng.") },
        { "furniture_shop", ("cửa hàng đồ nội thất", "Cửa hàng đồ nội thất {0} cung cấp các sản phẩm từ bàn ghế, tủ kệ đến các món đồ trang trí, giúp bạn tạo ra không gian sống thoải mái và sang trọng.") },
        { "garden_centre", ("trung tâm vườn", "Trung tâm vườn {0} cung cấp các loại cây trồng, hoa, dụng cụ làm vườn và các sản phẩm chăm sóc cây cối, giúp bạn tạo dựng một khu vườn đẹp và tươi mới.") },
        { "general", ("cửa hàng tổng hợp", "Cửa hàng tổng hợp {0} là nơi bạn có thể tìm thấy một loạt các sản phẩm từ nhu yếu phẩm hàng ngày đến các món đồ gia dụng, phục vụ nhu cầu mua sắm đa dạng.") },
        { "gift_shop", ("cửa hàng quà tặng", "Cửa hàng quà tặng {0} cung cấp các món quà độc đáo và ý nghĩa, từ đồ lưu niệm đến các sản phẩm thủ công mỹ nghệ, giúp bạn tìm được món quà phù hợp cho mọi dịp.") },
        { "golf_course", ("sân golf", "Sân golf {0} mang đến một không gian rộng rãi, lý tưởng cho các golfer, với các lỗ golf được thiết kế tỉ mỉ và các tiện ích hỗ trợ chơi golf chuyên nghiệp.") },
        { "graveyard", ("nghĩa trang", "Nghĩa trang {0} là nơi yên tĩnh và trang nghiêm, nơi các gia đình có thể tưởng niệm người đã khuất và tôn vinh ký ức của họ.") },
        { "greengrocer", ("cửa hàng rau củ quả", "Cửa hàng rau củ quả {0} cung cấp các loại rau củ tươi ngon, trái cây chất lượng, từ các sản phẩm địa phương đến nhập khẩu, đảm bảo sự tươi mới cho bữa ăn của bạn.") },
        { "guesthouse", ("nhà khách", "Nhà khách {0} mang đến không gian yên tĩnh và ấm cúng, lý tưởng cho những ai tìm kiếm một chỗ nghỉ dưỡng thoải mái và gần gũi.") },
        { "hairdresser", ("tiệm cắt tóc", "Tiệm cắt tóc {0} cung cấp các dịch vụ cắt, uốn, nhuộm và tạo kiểu tóc, với đội ngũ chuyên gia giàu kinh nghiệm để giúp bạn có một diện mạo mới.") },
        { "hospital", ("bệnh viện", "Bệnh viện {0} là cơ sở y tế hiện đại, cung cấp các dịch vụ khám chữa bệnh, phẫu thuật và cấp cứu, với đội ngũ bác sĩ và nhân viên y tế tận tâm.") },
        { "hostel", ("ký túc xá", "Ký túc xá {0} mang đến chỗ ở giá cả phải chăng cho du khách và sinh viên, với không gian chung tiện lợi và các tiện ích cơ bản để đảm bảo sự thoải mái trong suốt kỳ nghỉ.") },
        { "hotel", ("khách sạn", "Khách sạn bình dân {0} cung cấp các phòng nghỉ cơ bản, thoải mái và giá cả phải chăng, là lựa chọn lý tưởng cho những chuyến đi ngắn ngày hoặc du lịch tiết kiệm.") },
        { "jeweller", ("cửa hàng trang sức", "Cửa hàng trang sức {0} cung cấp các bộ sưu tập trang sức tinh xảo, từ nhẫn cưới đến các món quà cao cấp, được chế tác từ vàng, bạc và các vật liệu quý giá khác.") },
        { "kindergarten", ("mẫu giáo", "Mẫu giáo {0} mang đến môi trường học tập an toàn và sáng tạo cho trẻ nhỏ, với các chương trình giáo dục phát triển kỹ năng xã hội và trí tuệ trong những năm đầu đời.") },
        { "kiosk", ("quầy bán hàng", "Quầy bán hàng {0} cung cấp các sản phẩm tiện lợi như đồ ăn nhẹ, nước giải khát, báo chí và các vật phẩm cần thiết cho du khách hoặc người đi làm.") },
        { "laundry", ("dịch vụ giặt ủi", "Dịch vụ giặt ủi {0} giúp bạn giặt sạch quần áo, chăn màn và các vật dụng khác, với các dịch vụ giặt, là và phơi nhanh chóng và tiện lợi.") },
        { "library", ("thư viện", "Thư viện {0} cung cấp một kho tàng sách, báo và tài liệu nghiên cứu, là nơi lý tưởng cho việc học hỏi, đọc sách và khám phá kiến thức mới.") },
        { "lighthouse", ("ngọn hải đăng", "Ngọn hải đăng {0} là biểu tượng của sự an toàn cho các tàu thuyền, với ánh sáng chiếu sáng mạnh mẽ, giúp các tàu đánh dấu đường đi và tránh các rủi ro ngoài khơi.") },
        { "mall", ("trung tâm mua sắm", "Trung tâm mua sắm {0} là một khu phức hợp mua sắm hiện đại, với các cửa hàng thời trang, nhà hàng, rạp chiếu phim và các dịch vụ giải trí khác.") },
        { "market_place", ("chợ", "Chợ {0} là nơi bạn có thể tìm thấy các sản phẩm tươi ngon, từ rau củ quả, thực phẩm cho đến đồ gia dụng, mang đến trải nghiệm mua sắm sôi động và đa dạng.") },
        { "memorial", ("đài tưởng niệm", "Đài tưởng niệm {0} là nơi tưởng nhớ các sự kiện lịch sử quan trọng, với các công trình và bia đá ghi dấu những nhân vật và sự kiện đáng nhớ.") },
        { "mobile_phone_shop", ("cửa hàng điện thoại di động", "Cửa hàng điện thoại di động {0} cung cấp các dòng điện thoại mới nhất, phụ kiện và dịch vụ sửa chữa, giúp bạn lựa chọn thiết bị phù hợp với nhu cầu sử dụng.") },
        { "monument", ("tượng đài", "Tượng đài {0} là một công trình vĩ đại được dựng lên để tưởng nhớ những nhân vật lịch sử hoặc sự kiện quan trọng, là điểm dừng chân lý tưởng cho những ai muốn tìm hiểu thêm về quá khứ.") },
        { "motel", ("khách sạn bình dân", "Khách sạn bình dân {0} cung cấp các phòng nghỉ cơ bản, thoải mái và giá cả phải chăng, là lựa chọn lý tưởng cho những chuyến đi ngắn ngày hoặc du lịch tiết kiệm.") },
        { "museum", ("bảo tàng", "Bảo tàng {0} lưu giữ những hiện vật lịch sử quan trọng, mang đến cái nhìn sâu sắc về văn hóa và lịch sử của khu vực.") },
        { "nightclub", ("hộp đêm", "Hộp đêm {0} là nơi lý tưởng cho những ai yêu thích không khí sôi động, với âm nhạc sôi động, ánh sáng lấp lánh và các chương trình giải trí thú vị, mang đến trải nghiệm tiệc tùng không giới hạn.") },
        { "nursing_home", ("nhà dưỡng lão", "Nhà dưỡng lão {0} cung cấp môi trường sống an toàn và chăm sóc tận tình cho người cao tuổi, với đội ngũ y tế chuyên nghiệp và các hoạt động nâng cao chất lượng cuộc sống.") },
        { "observation_tower", ("tháp quan sát", "Tháp quan sát {0} mang đến tầm nhìn ngoạn mục từ trên cao, cho phép bạn chiêm ngưỡng phong cảnh xung quanh, từ cảnh sắc thiên nhiên đến các công trình kiến trúc biểu tượng.") },
        { "optician", ("cửa hàng kính mắt", "Cửa hàng kính mắt {0} cung cấp một loạt các loại kính thời trang và kính thuốc, cùng với các bài kiểm tra mắt chuyên nghiệp và lời khuyên từ các chuyên gia giúp bạn tìm ra cặp kính hoàn hảo.") },
        { "outdoor_shop", ("cửa hàng đồ thể thao ngoài trời", "Cửa hàng đồ thể thao ngoài trời {0} cung cấp tất cả các thiết bị và phụ kiện cần thiết cho các hoạt động ngoài trời như leo núi, cắm trại và thể thao mạo hiểm.") },
        { "park", ("công viên", "Công viên {0} là một địa điểm lý tưởng để thư giãn và tận hưởng không gian xanh, thích hợp cho các hoạt động ngoài trời như đi bộ, dã ngoại và chơi thể thao.") },
        { "pharmacy", ("nhà thuốc", "Nhà thuốc {0} cung cấp một loạt các sản phẩm dược phẩm, các mặt hàng chăm sóc sức khỏe và sắc đẹp, cùng với lời khuyên chuyên môn từ các dược sĩ có kinh nghiệm.") },
        { "picnic_site", ("khu dã ngoại", "Khu dã ngoại {0} là một địa điểm lý tưởng để thư giãn ngoài trời, được trang bị bàn picnic, ghế dài và không gian tự nhiên đẹp mắt, thích hợp cho các buổi gặp gỡ gia đình và các hoạt động giải trí.") },
        { "pitch", ("sân thể thao", "Sân thể thao {0} cung cấp một khu vực thể thao được bảo trì tốt, lý tưởng cho các hoạt động thể thao ngoài trời như bóng đá, rugby và các môn thể thao đồng đội khác.") },
        { "playground", ("sân chơi", "Sân chơi {0} là không gian vui vẻ và an toàn cho trẻ em, với các thiết bị chơi như xích đu, cầu trượt và các trò chơi khác giúp trẻ em giải trí và hoạt động.") },
        { "police", ("đồn cảnh sát", "Đồn cảnh sát {0} là trung tâm thực thi pháp luật cung cấp an ninh, bảo vệ và các dịch vụ cho cộng đồng địa phương, xử lý các tình huống khẩn cấp và thực hiện nhiệm vụ bảo vệ trật tự xã hội.") },
        { "post_office", ("bưu điện", "Bưu điện {0} cung cấp các dịch vụ bưu chính như gửi thư, giao nhận bưu kiện và bán tem, đảm bảo việc liên lạc thuận tiện và đáng tin cậy.") },
        { "prison", ("nhà tù", "Nhà tù {0} là cơ sở cải tạo nơi giam giữ những người bị kết án phạm tội, tập trung vào việc cải tạo và đảm bảo an ninh.") },
        { "pub", ("quán rượu", "Quán rượu {0} mang đến một không gian thân thiện và thoải mái, nơi bạn có thể thưởng thức nhiều loại đồ uống, món ăn nhẹ và các chương trình giải trí sống động trong không khí ấm cúng.") },
        { "public_building", ("tòa nhà công cộng", "Tòa nhà công cộng {0} là cơ sở phục vụ các dịch vụ chính phủ hoặc cộng đồng, cung cấp nhiều dịch vụ cho công chúng.") },
        { "recycling", ("trạm tái chế", "Trạm tái chế {0} chuyên thu gom và phân loại các vật liệu tái chế, thúc đẩy tính bền vững môi trường và giảm thiểu chất thải.") },
        { "restaurant", ("nhà hàng", "Nhà hàng {0} mang đến các món ăn đặc sản địa phương, tạo không gian ấm cúng và thoải mái cho thực khách.") },
        { "ruins", ("tàn tích", "Tàn tích {0} là những di tích còn sót lại của các công trình cổ, mang đến cái nhìn về quá khứ và kết nối với các nền văn minh và văn hóa lịch sử.") },
        { "school", ("trường học", "Trường học {0} là nơi giáo dục cung cấp môi trường học tập cho học sinh, giúp họ trang bị kiến thức và kỹ năng cho tương lai.") },
        { "shelter", ("nơi trú ẩn", "Nơi trú ẩn {0} cung cấp một môi trường an toàn và bảo vệ cho những người cần giúp đỡ, cung cấp chỗ ở tạm thời và các dịch vụ hỗ trợ.") },
        { "shoe_shop", ("cửa hàng giày", "Cửa hàng giày {0} cung cấp một loạt các loại giày dép cho mọi lứa tuổi, từ giày thể thao đến giày công sở, đảm bảo sự thoải mái và phong cách cho từng bước đi.") },
        { "sports_centre", ("trung tâm thể thao", "Trung tâm thể thao {0} là cơ sở được trang bị nhiều tiện nghi thể thao, lý tưởng cho những người yêu thích thể dục và thể thao để rèn luyện và tham gia các hoạt động.") },
        { "sports_shop", ("cửa hàng thể thao", "Cửa hàng thể thao {0} cung cấp đa dạng các thiết bị và phụ kiện thể thao, phục vụ nhu cầu của cả những vận động viên nghiệp dư và chuyên nghiệp.") },
        { "stadium", ("sân vận động", "Sân vận động {0} là một địa điểm lớn dành cho các sự kiện thể thao, hòa nhạc và các hoạt động quy mô lớn khác, với chỗ ngồi và cơ sở vật chất phục vụ hàng nghìn người.") },
        { "stationery", ("cửa hàng văn phòng phẩm", "Cửa hàng văn phòng phẩm {0} cung cấp một loạt các vật dụng văn phòng từ giấy, bút cho đến các công cụ tổ chức công việc, giúp bạn duy trì hiệu quả công việc và sự gọn gàng.") },
        { "supermarket", ("siêu thị", "Siêu thị {0} cung cấp đa dạng các sản phẩm tạp hóa, thực phẩm tươi sống và các mặt hàng tiêu dùng, là nơi lý tưởng để mua sắm cho mọi nhu cầu trong gia đình.") },
        { "swimming_pool", ("hồ bơi", "Hồ bơi {0} là nơi lý tưởng để thư giãn và tập thể dục, với các tiện nghi phù hợp cho mọi lứa tuổi và trình độ bơi.") },
        { "theatre", ("nhà hát", "Nhà hát {0} là nơi tổ chức các buổi biểu diễn nghệ thuật trực tiếp, bao gồm các vở kịch, nhạc kịch và opera, nhằm mang lại niềm vui và cảm hứng cho khán giả.") },
        { "theme_park", ("công viên chủ đề", "Công viên chủ đề {0} mang đến những trò chơi mạo hiểm, các điểm tham quan và hoạt động giải trí theo các chủ đề đặc biệt, cung cấp niềm vui và sự phiêu lưu cho mọi lứa tuổi.") },
        { "toilet", ("nhà vệ sinh công cộng", "Nhà vệ sinh công cộng {0} cung cấp các tiện nghi vệ sinh cơ bản cho khách tham quan, đảm bảo sự sạch sẽ và tiện lợi trong không gian công cộng.") },
        { "tourist_info", ("trung tâm thông tin du lịch", "Trung tâm thông tin du lịch {0} là nơi lý tưởng để du khách tìm kiếm thông tin về các điểm tham quan, nơi ăn uống, chỗ ở và các gợi ý về các hoạt động du lịch địa phương.") },
        { "tower", ("tháp", "Tháp {0} mang đến cảnh quan toàn cảnh xung quanh, cung cấp góc nhìn đặc biệt về cảnh quan hoặc toàn cảnh thành phố.") },
        { "town_hall", ("tòa thị chính", "Tòa thị chính {0} là trung tâm hành chính của chính quyền địa phương, nơi tổ chức các cuộc họp, sự kiện và cung cấp các dịch vụ công cộng cho cộng đồng.") },
        { "toy_shop", ("cửa hàng đồ chơi", "Cửa hàng đồ chơi {0} cung cấp đa dạng các món đồ chơi cho trẻ em, từ các trò chơi giáo dục đến những món đồ chơi giải trí vui nhộn, giúp phát triển sự sáng tạo và trí tuệ cho trẻ.") },
        { "track", ("đường đua", "Đường đua {0} là cơ sở dành cho các cuộc đua thể thao, bao gồm các môn thể thao như điền kinh, đua xe đạp hoặc đua xe, mang đến môi trường an toàn cho các vận động viên.") },
        { "travel_agent", ("đại lý du lịch", "Đại lý du lịch {0} giúp khách hàng lên kế hoạch và đặt tour du lịch, cung cấp lời khuyên về các điểm đến, tour du lịch và gói du lịch phù hợp với nhu cầu và ngân sách của khách.") },
        { "university", ("đại học", "Đại học {0} là cơ sở giáo dục đại học cung cấp các chương trình học thuật và cơ hội nghiên cứu trong nhiều lĩnh vực, giúp sinh viên chuẩn bị cho sự nghiệp và vai trò lãnh đạo.") },
        { "veterinary", ("bệnh viện thú y", "Bệnh viện thú y {0} cung cấp dịch vụ chăm sóc sức khỏe cho động vật, từ khám sức khỏe định kỳ đến các dịch vụ cấp cứu, đảm bảo sự khỏe mạnh và an toàn cho vật nuôi và động vật.") },
        { "viewpoint", ("điểm ngắm cảnh", "Điểm ngắm cảnh {0} mang đến vị trí lý tưởng để tận hưởng cảnh đẹp xung quanh, là nơi lý tưởng để chụp ảnh và tham quan.") },
        { "wastewater_plant", ("nhà máy xử lý nước thải", "Nhà máy xử lý nước thải {0} thực hiện việc xử lý và làm sạch nước thải để ngăn ngừa ô nhiễm môi trường và đảm bảo nước được tái sử dụng an toàn.") },
        { "water_tower", ("tháp nước", "Tháp nước {0} lưu trữ và cung cấp nước cho hệ thống cấp nước địa phương, đảm bảo cung cấp nước ổn định cho các cộng đồng xung quanh.") },
        { "water_well", ("giếng nước", "Giếng nước {0} là một hố sâu được khoan vào lòng đất để lấy nước ngầm, là nguồn cung cấp nước quan trọng cho các hộ gia đình và cộng đồng.") },
        { "water_works", ("công trình nước", "Công trình nước {0} bao gồm hệ thống cơ sở hạ tầng quản lý việc phân phối và xử lý nước, đảm bảo nguồn cung cấp nước sạch cho các khu vực thành thị và nông thôn.") },
        { "wayside_cross", ("thập giá bên đường", "Thập giá bên đường {0} là một biểu tượng tôn giáo được đặt bên vệ đường, thường là dấu hiệu cho các hành trình hành hương hoặc là biểu tượng của đức tin và sự suy ngẫm.") },
        { "wayside_shrine", ("miếu bên đường", "Miếu bên đường {0} là một công trình tôn giáo nhỏ nằm ven đường, thường được dâng cho một thánh hoặc thần, tạo không gian để suy ngẫm và tôn thờ.") },
        { "zoo", ("sở thú", "Sở thú {0} là nơi bạn có thể khám phá sự đa dạng của các loài động vật từ khắp nơi trên thế giới, với các chương trình giáo dục thú vị cho trẻ em.") },
};

    public static string GetPlaceType(string key) {
        return places.TryGetValue(key, out (string, string) value) ? value.Item1 : key;
    }

    public static string GetDescription(string key, string name) {
        try {
            return places.TryGetValue(key, out (string, string) value) ? string.Format(value.Item2, name) : key;
        } catch (Exception) {
            throw;
        }
    }

    public static string GetOpeningHours(string type) {
        return type.ToLower() switch {
            "archaeological" or "museum" or "attraction" or "ruins" or "monument" or "castle" or "memorial" => "9:00-18:00",
            "arts_centre" or "theatre" or "cinema" or "artwork" => "10:00-22:00",
            "bank" or "car_dealership" or "pharmacy" or "supermarket" or "department_store" or "post_office" or "kiosk" => "9:00-17:00",
            "bakery" or "cafe" or "fast_food" or "restaurant" or "pub" or "beverages" => "7:00-23:00",
            "atm" or "hotel" or "guesthouse" or "hostel" or "motel" => "24/7",
            "park" or "camp_site" or "picnic_site" or "playground" => "8:00-20:00",
            "zoo" or "aquarium" => "9:00-18:00",
            "gym" or "sports_centre" or "swimming_pool" or "stadium" => "6:00-22:00",
            "clinic" or "dentist" or "doctors" or "hospital" => "8:00-18:00",
            "laundry" or "convenience" or "shoe_shop" or "clothes" or "furniture_shop" or "gift_shop" => "10:00-20:00",
            "car_rental" or "car_wash" or "car_sharing" => "8:00-18:00",
            "nightclub" or "bar" or "biergarten" => "20:00-3:00",
            _ => "9:00-17:00",
        };
    }

    public static List<string> GetImageUrls(string type) {
        var imageUrls = new List<string>();

        switch (type.ToLower()) {
            case "archaeological":
            case "museum":
            case "monument":
            case "ruins":
            case "castle":
            case "memorial":
                imageUrls.Add("https://images.unsplash.com/photo-1514905552197-0610a4d8fd73");
                imageUrls.Add("https://images.unsplash.com/photo-1714592627070-cec4a7909c16");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1661919589683-f11880119fb7");
                imageUrls.Add("https://images.unsplash.com/photo-1509649850376-32bd5dc08246");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1661873863027-51b409f112f5");
                break;

            case "artworks":
            case "arts_centre":
            case "artwork":
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1706430433607-48f37bdd71b8");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1705941790963-d9eae5cdab30");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1706548911887-791ddf52ac48");
                imageUrls.Add("https://images.unsplash.com/photo-1655069482983-d87066eefd01");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1677609991615-0657859f0a8a");
                break;

            case "bakery":
                imageUrls.Add("https://images.unsplash.com/photo-1515182629504-727d7753751f");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1665669263531-cdcbe18e7fe4");
                imageUrls.Add("https://images.unsplash.com/photo-1534432182912-63863115e106");
                imageUrls.Add("https://images.unsplash.com/photo-1528591922185-a0eb2f8f50b6");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1675604274302-665e7e65021e");
                break;

            case "bank":
            case "atm":
                imageUrls.Add("https://images.unsplash.com/photo-1430276084627-789fe55a6da0");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1661405647490-a2ccaaa44051");
                imageUrls.Add("https://images.unsplash.com/photo-1562235323-cd8f789b0445");
                imageUrls.Add("https://images.unsplash.com/photo-1531471531302-ba2ae5bf6489");
                imageUrls.Add("https://images.unsplash.com/photo-1616689069431-6fcf2b338438");
                break;

            case "cafe":
            case "restaurant":
            case "fast_food":
                imageUrls.Add("https://images.unsplash.com/photo-1552644607-25fc193d809a");
                imageUrls.Add("https://images.unsplash.com/photo-1581574470202-7e344021b092");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1727456097885-babe458a054c");
                imageUrls.Add("https://images.unsplash.com/photo-1559069919-c3ccb589630d");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1677528572994-a248688d07d3");
                break;

            case "hotel":
            case "guesthouse":
            case "hostel":
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1724659215886-3674d0a05845");
                imageUrls.Add("https://images.unsplash.com/photo-1445991842772-097fea258e7b");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1683649964220-0fa832aa7068");
                imageUrls.Add("https://images.unsplash.com/photo-1445019980597-93fa8acb246c");
                imageUrls.Add("https://images.unsplash.com/photo-1455587734955-081b22074882");
                break;

            case "park":
            case "picnic_site":
            case "playground":
                imageUrls.Add("https://images.unsplash.com/photo-1686050614530-18eb5fbd40c4");
                imageUrls.Add("https://images.unsplash.com/photo-1564409972016-2825589beaed");
                imageUrls.Add("https://images.unsplash.com/photo-1622050956578-94fd044a0ada");
                imageUrls.Add("https://images.unsplash.com/photo-1686051239790-2b5b8b0f3769");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1686920246233-b6940094183c");
                break;

            case "hospital":
            case "clinic":
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1726862913323-d419c847ea07");
                imageUrls.Add("https://images.unsplash.com/photo-1596541223130-5d31a73fb6c6");
                imageUrls.Add("https://images.unsplash.com/photo-1580281657702-257584239a55");
                imageUrls.Add("https://images.unsplash.com/photo-1516841273335-e39b37888115");
                imageUrls.Add("https://images.unsplash.com/photo-1519494026892-80bbd2d6fd0d");
                break;

            case "nightclub":
            case "bar":
                imageUrls.Add("https://images.unsplash.com/photo-1519214605650-76a613ee3245");
                imageUrls.Add("https://images.unsplash.com/photo-1708573061065-0194ddf8b20b");
                imageUrls.Add("https://images.unsplash.com/photo-1712569537046-a5dee3551da4");
                imageUrls.Add("https://images.unsplash.com/photo-1485030056468-3820ff9e6e90");
                imageUrls.Add("https://images.unsplash.com/photo-1569924995012-c4c706bfcd51");
                break;

            case "zoo":
                imageUrls.Add("https://images.unsplash.com/photo-1503918756811-975bd3397178");
                imageUrls.Add("https://images.unsplash.com/photo-1627981440910-552a0b1d7450");
                imageUrls.Add("https://images.unsplash.com/photo-1668375139213-3162874e79de");
                imageUrls.Add("https://images.unsplash.com/photo-1612738331950-40abbddce9aa");
                imageUrls.Add("https://images.unsplash.com/photo-1633704348270-8487cbf345f6");
                break;

            default:
                imageUrls.Add("https://images.unsplash.com/photo-1628066068625-015ea7bcc21a");
                imageUrls.Add("https://images.unsplash.com/photo-1521092593988-d2188e25a77d");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1688069515896-9dc5c0ef299a");
                imageUrls.Add("https://images.unsplash.com/photo-1568307303686-1fcffdedd4a5");
                imageUrls.Add("https://plus.unsplash.com/premium_photo-1690474616906-4d9f87ae8dcd");
                break;
        }

        return imageUrls;
    }

    public static List<string> GetComments(string type) {
        return type.ToLower() switch {
            "archaeological" => ["Địa điểm mang đậm dấu ấn lịch sử.", "Nơi lý tưởng để tìm hiểu về quá khứ."],
            "arts_centre" => ["Không gian nghệ thuật độc đáo và sáng tạo.", "Thực sự thích nơi này, rất nhiều chương trình thú vị!"],
            "artwork" => ["Tác phẩm nghệ thuật đẹp và ấn tượng.", "Một tác phẩm rất ý nghĩa và có chiều sâu."],
            "atm" => ["ATM tiện lợi, không cần xếp hàng lâu.", "Giao dịch nhanh chóng, dễ sử dụng."],
            "attraction" => ["Địa điểm rất hấp dẫn và thú vị.", "Nơi tuyệt vời để thư giãn và chụp ảnh."],
            "bakery" => ["Bánh mì ở đây thơm ngon.", "Mùi bánh tươi mới thật quyến rũ!"],
            "bank" => ["Nhân viên ngân hàng thân thiện và nhiệt tình.", "Dịch vụ tốt và nhanh chóng."],
            "bar" => ["Quán bar có không gian ấm cúng.", "Đồ uống ngon và phong cách phục vụ tốt."],
            "beauty_shop" => ["Dịch vụ làm đẹp rất chuyên nghiệp.", "Rất hài lòng với phong cách phục vụ ở đây!"],
            "bench" => ["Ghế ngồi thoải mái, rất tiện để nghỉ ngơi.", "Vị trí lý tưởng để ngồi ngắm cảnh xung quanh."],
            "beverages" => ["Đồ uống đa dạng và rất ngon miệng.", "Phục vụ đồ uống nhanh và chu đáo."],
            "bicycle_rental" => ["Thuê xe đạp dễ dàng và nhanh chóng.", "Xe đạp chất lượng tốt và giá thuê hợp lý."],
            "bicycle_shop" => ["Cửa hàng xe đạp có nhiều lựa chọn.", "Nhân viên nhiệt tình tư vấn, phụ tùng đầy đủ."],
            "biergarten" => ["Không gian ngoài trời thoáng đãng, thích hợp cho buổi tối.", "Bia ngon và phục vụ thân thiện."],
            "bookshop" => ["Hiệu sách có nhiều đầu sách phong phú.", "Không gian yên tĩnh, rất thích hợp để tìm sách hay."],
            "butcher" => ["Thịt tươi ngon và đa dạng.", "Cửa hàng sạch sẽ, nhân viên nhiệt tình."],
            "cafe" => ["Quán cà phê có không gian đẹp và ấm cúng.", "Cà phê rất ngon và nhân viên phục vụ nhiệt tình."],
            "camp_site" => ["Khu cắm trại rộng rãi và an toàn.", "Nơi lý tưởng để hòa mình vào thiên nhiên."],
            "car_dealership" => ["Nhiều mẫu xe đa dạng và giá hợp lý.", "Nhân viên tư vấn chuyên nghiệp và tận tình."],
            "car_rental" => ["Dịch vụ cho thuê xe tốt, xe mới và sạch sẽ.", "Thủ tục nhanh chóng, giá thuê hợp lý."],
            "car_sharing" => ["Dịch vụ chia sẻ xe tiện lợi và dễ sử dụng.", "Xe luôn được bảo trì tốt, đáng tin cậy."],
            "car_wash" => ["Rửa xe sạch sẽ, nhân viên làm việc nhanh nhẹn.", "Dịch vụ rửa xe chuyên nghiệp và giá phải chăng."],
            "caravan_site" => ["Khu cắm trại có đủ tiện nghi và rất sạch sẽ.", "Không gian yên tĩnh, rất thích hợp cho gia đình."],
            "castle" => ["Lâu đài cổ kính và đẹp mắt.", "Một điểm tham quan không thể bỏ qua với kiến trúc tuyệt vời."],
            "chalet" => ["Nhà gỗ ấm cúng và gần gũi thiên nhiên.", "Nơi lý tưởng để nghỉ dưỡng."],
            "chemist" => ["Nhà thuốc có đầy đủ sản phẩm và nhân viên tư vấn nhiệt tình.", "Dịch vụ tốt và giá cả hợp lý."],
            "cinema" => ["Rạp chiếu phim hiện đại và thoải mái.", "Chất lượng hình ảnh và âm thanh tuyệt vời."],
            "clinic" => ["Phòng khám sạch sẽ và phục vụ chuyên nghiệp.", "Bác sĩ tận tình và chu đáo."],
            "clothes" => ["Cửa hàng quần áo phong phú và giá cả phải chăng.", "Nhiều kiểu dáng đẹp và thời trang."],
            "college" => ["Trường học với môi trường giáo dục chuyên nghiệp.", "Giảng viên tận tâm và nhiệt tình."],
            "comms_tower" => ["Tháp truyền thông cao và nổi bật.", "Kiến trúc ấn tượng và độc đáo."],
            "community_centre" => ["Trung tâm cộng đồng có nhiều hoạt động bổ ích.", "Không gian rộng rãi và phục vụ tốt cho cộng đồng."],
            "computer_shop" => ["Cửa hàng máy tính có nhiều sản phẩm và dịch vụ tốt.", "Nhân viên am hiểu và hỗ trợ nhiệt tình."],
            "convenience" => ["Cửa hàng tiện lợi, mọi thứ đều sẵn có.", "Phục vụ nhanh chóng, tiện lợi và giá hợp lý."],
            "courthouse" => ["Tòa án có kiến trúc trang trọng.", "Nơi phục vụ công lý và bảo vệ quyền lợi công dân."],
            "dentist" => ["Nha sĩ giỏi và rất tận tâm.", "Dịch vụ nha khoa chuyên nghiệp và thân thiện."],
            "department_store" => ["Trung tâm mua sắm với nhiều mặt hàng phong phú.", "Không gian thoải mái và phục vụ tốt."],
            "doctors" => ["Bác sĩ tận tâm và có chuyên môn cao.", "Phòng khám sạch sẽ và phục vụ chu đáo."],
            "doityourself" => ["Cửa hàng cung cấp nhiều dụng cụ và thiết bị cho tự làm.", "Nhân viên nhiệt tình tư vấn và hướng dẫn."],
            "embassy" => ["Đại sứ quán làm việc chuyên nghiệp và hỗ trợ tốt.", "Thủ tục nhanh chóng, nhân viên tận tình."],
            "fast_food" => ["Đồ ăn nhanh, giá hợp lý và hương vị ổn.", "Phục vụ nhanh, rất tiện cho bữa ăn gọn lẹ."],
            "fire_station" => ["Trạm cứu hỏa hiện đại và chuyên nghiệp.", "Cảm thấy an tâm với dịch vụ cứu hỏa ở đây."],
            "florist" => ["Hoa tươi và đẹp, nhiều sự lựa chọn.", "Cửa hàng hoa có phong cách cắm hoa rất sáng tạo."],
            "food_court" => ["Khu ẩm thực đa dạng món ăn từ nhiều quốc gia.", "Không gian thoải mái, đồ ăn phong phú và giá hợp lý."],
            "fort" => ["Pháo đài cổ kính, nơi đáng để khám phá.", "Kiến trúc ấn tượng, lịch sử phong phú."],
            "fountain" => ["Đài phun nước đẹp, tạo cảm giác thư giãn.", "Nơi lý tưởng để dạo chơi và chụp ảnh."],
            "furniture_shop" => ["Cửa hàng nội thất với nhiều mẫu mã đẹp và hiện đại.", "Nhân viên tư vấn nhiệt tình, đồ nội thất chất lượng tốt."],
            "garden_centre" => ["Trung tâm cây cảnh đa dạng và phong phú.", "Nhân viên am hiểu và hỗ trợ tận tình về cây trồng."],
            "general" => ["Địa điểm phục vụ đầy đủ các nhu cầu cơ bản.", "Dịch vụ tốt, giá cả phải chăng."],
            "gift_shop" => ["Cửa hàng quà tặng với nhiều sản phẩm độc đáo.", "Món quà ở đây thật sáng tạo và ý nghĩa."],
            "golf_course" => ["Sân golf rộng rãi và được chăm sóc kỹ lưỡng.", "Không gian yên tĩnh, thích hợp để thư giãn và chơi golf."],
            "graveyard" => ["Nghĩa trang yên tĩnh và trang nghiêm.", "Nơi được chăm sóc sạch sẽ và gọn gàng."],
            "greengrocer" => ["Cửa hàng rau củ tươi ngon và giá hợp lý.", "Sản phẩm tươi mới và đa dạng."],
            "guesthouse" => ["Nhà khách thoải mái và thân thiện.", "Phòng ốc sạch sẽ, nhân viên nhiệt tình."],
            "hairdresser" => ["Tiệm cắt tóc chuyên nghiệp và thân thiện.", "Dịch vụ làm tóc đa dạng và chất lượng cao."],
            "hospital" => ["Bệnh viện hiện đại, bác sĩ giỏi và tận tâm.", "Dịch vụ y tế tốt và đầy đủ tiện nghi."],
            "hostel" => ["Nhà nghỉ giá rẻ và phòng sạch sẽ.", "Nhân viên thân thiện và nhiệt tình."],
            "hotel" => ["Khách sạn sang trọng, phòng ốc đẹp và tiện nghi.", "Phục vụ chu đáo, đáng giá tiền."],
            "jeweller" => ["Cửa hàng trang sức có nhiều mẫu mã đẹp.", "Nhân viên tư vấn nhiệt tình và chuyên nghiệp."],
            "kindergarten" => ["Trường mẫu giáo thân thiện và an toàn cho trẻ.", "Giáo viên tận tâm, cơ sở vật chất tốt."],
            "kiosk" => ["Quầy bán hàng tiện lợi và phục vụ nhanh.", "Có đầy đủ đồ dùng thiết yếu và đồ ăn nhẹ."],
            "laundry" => ["Dịch vụ giặt ủi nhanh chóng và sạch sẽ.", "Nhân viên nhiệt tình, giá cả hợp lý."],
            "library" => ["Thư viện yên tĩnh, sách phong phú và đa dạng.", "Không gian lý tưởng để học tập và nghiên cứu."],
            "lighthouse" => ["Ngọn hải đăng đẹp và thu hút.", "Từ đây có thể nhìn toàn cảnh biển rất đẹp."],
            "mall" => ["Trung tâm thương mại rộng lớn và đa dạng sản phẩm.", "Nơi lý tưởng để mua sắm và giải trí."],
            "market_place" => ["Chợ có nhiều sản phẩm địa phương tươi ngon.", "Không gian nhộn nhịp và nhiều lựa chọn mua sắm."],
            "memorial" => ["Đài tưởng niệm trang nghiêm và ý nghĩa.", "Nơi tôn vinh và nhớ về những người đã hy sinh."],
            "mobile_phone_shop" => ["Cửa hàng điện thoại có nhiều mẫu mã mới.", "Nhân viên tư vấn nhiệt tình, nhiều khuyến mãi."],
            "monument" => ["Công trình kiến trúc đặc biệt, mang nhiều ý nghĩa lịch sử.", "Nơi đáng để tham quan và tìm hiểu."],
            "motel" => ["Nhà nghỉ tiện nghi, phù hợp cho các chuyến đi ngắn.", "Phòng sạch sẽ, dịch vụ chu đáo."],
            "museum" => ["Bảo tàng có nhiều hiện vật giá trị và phong phú.", "Nơi lý tưởng để tìm hiểu lịch sử và văn hóa."],
            "nightclub" => ["Câu lạc bộ đêm sôi động và âm nhạc hay.", "Không gian vui nhộn, thích hợp để giải trí."],
            "nursing_home" => ["Nhà dưỡng lão sạch sẽ, nhân viên tận tình.", "Chăm sóc chu đáo, nơi yên bình cho người lớn tuổi."],
            "observation_tower" => ["Tháp quan sát với tầm nhìn rộng và đẹp.", "Nơi lý tưởng để ngắm cảnh từ trên cao."],
            "optician" => ["Cửa hàng mắt kính có nhiều mẫu đẹp và chất lượng.", "Nhân viên tư vấn chuyên nghiệp, tận tình."],
            "outdoor_shop" => ["Cửa hàng bán đồ dã ngoại đa dạng và chất lượng.", "Phù hợp cho người thích phiêu lưu và thể thao."],
            "park" => ["Công viên xanh mát, thoáng đãng, nhiều cây cối.", "Nơi lý tưởng để đi dạo và thư giãn."],
            "pharmacy" => ["Nhà thuốc đầy đủ các loại thuốc và tư vấn tận tâm.", "Dịch vụ tốt, hỗ trợ khách hàng nhiệt tình."],
            "picnic_site" => ["Khu dã ngoại rộng rãi, không gian xanh tươi mát.", "Phù hợp để đi cùng gia đình và bạn bè."],
            "pitch" => ["Sân chơi rộng rãi và được chăm sóc tốt.", "Thích hợp để tổ chức các hoạt động thể thao."],
            "playground" => ["Khu vui chơi an toàn và có nhiều trò chơi cho trẻ.", "Nơi lý tưởng để cho trẻ em vui chơi."],
            "police" => ["Đồn cảnh sát làm việc chuyên nghiệp, hỗ trợ nhanh.", "Cảm giác an toàn khi có lực lượng ở đây."],
            "post_office" => ["Bưu điện phục vụ nhanh chóng và hiệu quả.", "Nhân viên nhiệt tình, giá cả dịch vụ hợp lý."],
            "prison" => ["Nhà tù được quản lý chặt chẽ và nghiêm túc.", "Nơi phục vụ công lý và bảo vệ an ninh."],
            "pub" => ["Quán rượu với không gian ấm cúng, đồ uống ngon.", "Phục vụ nhiệt tình, thích hợp để thư giãn."],
            "public_building" => ["Công trình công cộng sạch sẽ và rộng rãi.", "Dịch vụ công cộng tốt, phục vụ người dân hiệu quả."],
            "recycling" => ["Trạm tái chế tiện lợi và dễ sử dụng.", "Hoạt động tích cực cho bảo vệ môi trường."],
            "restaurant" => ["Nhà hàng phục vụ món ăn ngon và không gian đẹp.", "Phục vụ chu đáo, giá cả hợp lý."],
            "ruins" => ["Di tích cổ kính, mang đậm dấu ấn lịch sử.", "Nơi lý tưởng để tìm hiểu về quá khứ và văn hóa."],
            "school" => ["Trường học có cơ sở vật chất tốt, giáo viên tận tâm.", "Môi trường học tập lành mạnh và an toàn."],
            "shelter" => ["Nơi trú ẩn sạch sẽ và an toàn.", "Phục vụ tốt cho những người cần chỗ trú tạm thời."],
            "shoe_shop" => ["Cửa hàng giày đa dạng mẫu mã, giá cả phải chăng.", "Nhân viên nhiệt tình, sản phẩm chất lượng."],
            "sports_centre" => ["Trung tâm thể thao có đầy đủ thiết bị và dịch vụ.", "Nơi lý tưởng để rèn luyện sức khỏe."],
            "sports_shop" => ["Cửa hàng đồ thể thao phong phú và chất lượng.", "Phục vụ tốt cho nhu cầu thể thao và tập luyện."],
            "stadium" => ["Sân vận động lớn và hiện đại, không gian rộng rãi.", "Nơi tuyệt vời để xem các trận đấu thể thao."],
            "stationery" => ["Cửa hàng văn phòng phẩm đầy đủ và tiện lợi.", "Nhiều lựa chọn đồ dùng học tập và văn phòng."],
            "supermarket" => ["Siêu thị có nhiều sản phẩm, giá cả hợp lý.", "Nơi lý tưởng để mua sắm đồ gia dụng và thực phẩm."],
            "swimming_pool" => ["Bể bơi sạch sẽ, nước trong và an toàn.", "Phù hợp cho gia đình và trẻ em."],
            "theatre" => ["Nhà hát với chương trình biểu diễn đặc sắc.", "Không gian đẹp, âm thanh và ánh sáng tốt."],
            "theme_park" => ["Công viên giải trí đa dạng trò chơi, thú vị.", "Nơi lý tưởng để vui chơi cùng gia đình."],
            "toilet" => ["Nhà vệ sinh sạch sẽ và tiện nghi.", "Dịch vụ vệ sinh tốt, luôn có giấy và xà phòng."],
            "tourist_info" => ["Trung tâm thông tin du lịch hỗ trợ tận tình.", "Nhiều thông tin hữu ích cho du khách."],
            "tower" => ["Tháp cao, thiết kế đẹp và độc đáo.", "Từ đây có thể nhìn thấy toàn cảnh thành phố."],
            "town_hall" => ["Tòa thị chính trang nghiêm, kiến trúc đẹp.", "Nơi làm việc chuyên nghiệp của chính quyền địa phương."],
            "toy_shop" => ["Cửa hàng đồ chơi phong phú, phù hợp cho trẻ em.", "Nhiều món đồ chơi sáng tạo và an toàn."],
            "track" => ["Đường chạy rộng rãi, thích hợp cho các buổi tập thể thao.", "Sân tập tốt và sạch sẽ."],
            "travel_agent" => ["Dịch vụ du lịch chu đáo và tư vấn tận tâm.", "Nhiều gói tour hấp dẫn và giá cả hợp lý."],
            "university" => ["Đại học có môi trường học tập chuyên nghiệp.", "Giáo viên tận tâm, cơ sở vật chất hiện đại."],
            "veterinary" => ["Phòng khám thú y với bác sĩ giỏi và nhiệt tình.", "Dịch vụ chăm sóc thú cưng tốt, giá cả hợp lý."],
            "viewpoint" => ["Địa điểm ngắm cảnh với tầm nhìn đẹp.", "Nơi lý tưởng để thư giãn và chụp ảnh."],
            "wastewater_plant" => ["Nhà máy xử lý nước thải hiện đại và hiệu quả.", "Đóng góp quan trọng cho môi trường sạch hơn."],
            "water_tower" => ["Tháp nước cao, cung cấp nước sạch cho khu vực.", "Công trình kỹ thuật tốt và an toàn."],
            "water_well" => ["Giếng nước sạch và dễ tiếp cận.", "Nguồn nước ổn định và an toàn cho dân cư."],
            "water_works" => ["Công trình cấp nước ổn định, bảo đảm nhu cầu sinh hoạt.", "Hỗ trợ tốt cho đời sống của người dân."],
            "wayside_cross" => ["Thánh giá bên đường đẹp và ý nghĩa.", "Nơi linh thiêng, thu hút nhiều người ghé thăm."],
            "wayside_shrine" => ["Miếu thờ nhỏ bên đường rất trang nghiêm.", "Nơi linh thiêng, được người dân tôn trọng."],
            "zoo" => ["Vườn thú rộng lớn và nhiều loài động vật.", "Các bé rất thích tham quan nơi này."],
            _ => ["Địa điểm thú vị.", "Nơi đáng để ghé thăm!"],
        };
    }

}
