import { createClient } from '@supabase/supabase-js';

const supabaseUrl = 'https://evzlvrpphtllqredsnqy.supabase.co';
const supabaseKey = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImV2emx2cnBwaHRsbHFyZWRzbnF5Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzI1NjEwMzAsImV4cCI6MjA0ODEzNzAzMH0.zWCv76vDc51VcwWaDpNY2P3NzNVJh_8YHQ-aK08It8Y';

export const supabase = createClient(supabaseUrl, supabaseKey);
