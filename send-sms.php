<?php
// تنظیمات پیامک
$api_key = "YOUR_API_KEY"; // کلید API سرویس پیامک
$sender = "MaximaHome"; // شماره فرستنده
$receptor = "09902524062"; // شماره گیرنده
$message = ""; // متن پیامک

// دریافت اطلاعات از فرم
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $name = $_POST['name'];
    $phone = $_POST['phone'];
    $carModel = $_POST['carModel'];
    $serviceType = $_POST['serviceType'];
    $date = $_POST['date'];
    $time = $_POST['time'];
    $description = $_POST['description'];

    // ساخت متن پیامک
    $message = "رزرو وقت جدید:\n";
    $message .= "نام: " . $name . "\n";
    $message .= "شماره تماس: " . $phone . "\n";
    $message .= "مدل خودرو: " . $carModel . "\n";
    $message .= "نوع خدمت: " . $serviceType . "\n";
    $message .= "تاریخ: " . $date . "\n";
    $message .= "ساعت: " . $time . "\n";
    $message .= "توضیحات: " . $description;

    // ارسال پیامک
    $url = "https://api.kavenegar.com/v1/{$api_key}/sms/send.json";
    $data = array(
        'receptor' => $receptor,
        'sender' => $sender,
        'message' => $message
    );

    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_POST, 1);
    curl_setopt($ch, CURLOPT_POSTFIELDS, $data);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    $response = curl_exec($ch);
    curl_close($ch);

    // ارسال پاسخ به فرم
    echo json_encode(['success' => true]);
} else {
    echo json_encode(['success' => false, 'message' => 'Invalid request method']);
}
?> 